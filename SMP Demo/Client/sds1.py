#!/usr/bin/python2.7
import socket
import pcapy
import impacket
import sys
import string
from impacket import ImpactDecoder, ImpactPacket
from impacket.ImpactDecoder import EthDecoder
import packets
from packets import SMP, SDSReq, SDSResponse
import time
from pcapy import open_live
import random
import re

ETH_MY_MAC = 0x10,0x10,0x10,0x10,0x10,0x10 #mac 10:10:10:10:10:10
ETH_SMP_TYPE = 0x88b5
ETH_SDS_TYPE = 0x88b6

class role:
    CLIENT = 0
    PEER = 1
    SERVER = 2
    TRACKER = 3
    PROXY = 4

class smp_ep:
    #r         #role
    #serviceID      #10 byte service IDs
    def __init__(self):
        self.serviceID = 'zzzzz'+''.join(random.choice(string.ascii_lowercase) for _ in range(5))
        self.r = 'peer'
    

class smp_ep_eth:
    #eth_addr       #6 byte eth NIC addresses
    #port           #32 bit port nos
    def __init__(self,eth_addr,port):
        self.eth_addr = ETH_MY_MAC
        self.port = port


    #use pcapy to capture packets- no bind, listen stuff- use threads to serve multiple connections
host = socket.gethostbyname(socket.gethostname())
tab = {('ca4433b4ad',0):(ETH_MY_MAC,1000,3600),('ca4433b4ad',2):(ETH_MY_MAC,1001,3600)}
def directory_smp(ep):  #The specification tells me to return 0 on success, the message flow diagram tells me to return the ETH Addr, port
    if tab.has_key((ep.serviceID,ep.r)):
        return (tab[(ep.serviceID,ep.r)])
    else:
        return -1

def main():
    p = open_live("eth0",34, False, 100)
    p.setfilter("ether dst 10:10:10:10:10:10 ")
    p.loop(50, EthDecoder1) #50- denotes number of connections that can be serviced
def EthDecoder1(hdr,data):
    eth = EthDecoder().decode(data)
    sdsReq = eth.child()
    str1 = sdsReq.__str__()
    print len(str1)
    print str1
    print "1 "+str1[5:9]+" 2 "+str1[10:14]
    ver = str1[5:7]
    typ = str1[7:9]
    rlen = str1[10:14]
    tid1 = (str1[15:17], str1[17:19], str1[20:22], str1[22:24])
    tid = tuple(int('0x'+i, 16) for i in tid1)
    sid1 = str1[25:29]+str1[30:34]+str1[35:39]+ str1[40:44]+str1[65:69] #sid in hex
    sid4 = tuple(re.findall('..', sid1))
    sid2 = tuple(chr(int('0x'+i, 16)) for i in sid4) #hex->char
    sid3 = ''.join(sid2) #stringified
    
    sid = tuple(int('0x'+i, 16) for i in sid4) #hex->dec
    print ver, typ, rlen, tid, sid1, sid4, sid
    role = int(str1[70:74],16)
    print eth.get_ether_shost()

    ep = smp_ep()
    ep.serviceID = sid3
    ep.r = role
    res = directory_smp(ep)
    print res
    
    ethAddr = res[0]
    port = res[1]
    ttl = res[2]
    
    sdsResp1 = SDSResponse()
    sdsResp1.set_tid(tid)
    sdsResp1.set_sid(sid)
    sdsResp1.set_role(role)
    sdsResp1.set_ethAddress(ethAddr)
    sdsResp1.set_ttl(ttl)
    sdsResp1.set_port(port)

    ethResp = ImpactPacket.Ethernet()
    ethResp.set_ether_type(eth.get_ether_type())
    ethResp.set_ether_shost(eth.get_ether_dhost())
    ethResp.set_ether_dhost(eth.get_ether_shost())
    ethResp.contains(sdsResp1)
    s1 = socket.socket(socket.PF_PACKET, socket.SOCK_RAW, socket.htons(ETH_SDS_TYPE))
    s1.bind(("eth0",0))
    s1.send(ethResp.get_packet())

    
    
    
    

    

if __name__ == "__main__":
    main()


        
        
