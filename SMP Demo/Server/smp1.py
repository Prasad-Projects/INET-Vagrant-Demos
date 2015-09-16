#!/usr/bin/python2.7
import socket
import pcapy
import impacket
import sys
import string
import time
from impacket import ImpactDecoder, ImpactPacket
from impacket.ImpactDecoder import EthDecoder
import sds1
import random
import packets
from packets import SMP, SDSReq, SDSResponse
import re, os
from pcapy import open_live

#generate a random 32-but port no for non-server end points(sock_smp calls)

ETH_MY_MAC = 0x40,0x40,0x40,0x40,0x40,0x41 #mac 40:40:40:40:40:41 #host mac address
ETH_SMP_TYPE = 0x88b5
ETH_SDS_TYPE = 0x88b6
ETH_SDS = 0x40,0x40,0x40,0x40 ,0x40,0x40 #lan sds mac address
SPORT = 54321 #port of this host

ETH_REMOTE_MAC = 0x40, 0x40, 0x40, 0x40, 0x40, 0x39
ETH_REMOTE_MAC1 = "40:40:40:40:40:38"
ETH_REMOTE_PORT = 62003

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
        self.serviceID = re.findall('..','zzzzz'+''.join(random.choice(string.ascii_lowercase) for _ in range(5))) #5-tupled field
        self.r = 'peer'
    

class smp_ep_eth:
    #eth_addr       #6 byte eth NIC addresses
    #port           #32 bit port nos- generate randomly for non-server EP's
    def __init__(self,eth_addr,port):
        self.eth_addr = ETH_MY_MAC
        self.port = port

tab_smp = {} #hashed with smpfd's to make closing faster; key=smpfd, fields= socketObject, serviceID, r, eth, port, ttl
buf1 = ''
bytes11 = 0
def socket_smp(ep,addrlen):  #socket needed only for sending, for receiving pcapy is good; if role is server=2, then register with EPM(choice=1), else-generate random 32-bit port nos, check with EPM(choice='2'), try fetching corresponding eth, port, ttl, auth, from EPM(choice = '4'), if reply is '0', go to SDS, after receiving reply from SDS, insert into EMP(choice ='3')
#first send the request to SDS server- obtain eth
   """ try:
        s = socket.socket(socket.PF_PACKET, socket.SOCK_RAW, socket.htons(ETH_SMP_TYPE))
        response = sds.directory_smp(ep, addrlen, ep_eth, ethlen)  #call only for r != 'client'
        if response == -1:
            return -2
        tab_smp[s.fileno]=(s,ep.serviceID,ep.r)
        return s.fileno
    except:
        return -1"""
   print os.path.exists('EPMr')
   pout = os.open('EPMr', os.O_WRONLY)
   pin = open('EPMw', 'r')
   os.write(pout, '1\n')
   port = int(''.join(random.choice('10') for _ in range(32)), 2) #least chance that ports will be repeated- randomized
   if ep.r == 2:
       os.write(pout, ep.serviceID+" "+"2"+" "+str(port)+"\n")
       print 'Written'
       res = pin.readline()[:-1]
       if res == '0':
           return -2
       try:
           s1 = socket.socket(socket.PF_PACKET, socket.SOCK_RAW, socket.htons(ETH_SMP_TYPE))
           tab_smp[s1.fileno()]=(s1,ep.serviceID,ep.r)
           return s1.fileno()
       except:
           return -1
   

def close_smp(smpfd):
    if tab_smp.has_key(smpfd):
        tab_smp[smpfd][0].close()
        tab_smp.pop(smpfd)
        return 0
    return -1

#only those applications/end\ points? whose smpfd is in tab_smp will be allowed to make smp_send and smp_recvfrom calls- associate state abstraction
def sendto_smp(smpfd, buf, bytes1, to): #int sendto_smp(int smpfd,const void *buf,size_t bytes,const struct smp_ep *to,socklen_t addrlen);
    print tab_smp
    buf1 = buf
    bytes11 = bytes1
    if (tab_smp.has_key(smpfd)) and (len(buf) == bytes1):
        #communicate with EPM
        pout = os.open('EPMr', os.O_WRONLY)
        pin = open('EPMw', 'r')
        os.write(pout, '4\n')
        os.write(pout, to.serviceID+" "+str(to.r)+"\n")
        print 'Written sendto_smp'
        res = pin.readline()[:-1]
        if res != '0':
           lis = res.split(" ")
           ethAddress = lis[0]
           port = lis[1]
           ttl = int(lis[2])
           auth = lis[3]
           if ttl > 0:
                sock1 = socket.socket()
                for key in tab_smp.keys():
                   if tab_smp[key] == (sid1, role1):
                       sock1 = tab_smp[key][0]
                       print sock1
                       break
                sock1.bind(("eth0", 0))
                smpPacket = SMP()
                smpPacket.set_plen(bytes11)
                smpPacket.set_dport(int('0x'+port, 16))
                smpPacket.set_sport(SPORT)
                smpPacket.contains(ImpactPacket.Data(buf1))
                
                ethsmp = ImpactPacket.Ethernet()
                
                ethsmp.set_ether_shost(ETH_MY_MAC)
                
                ethAdd1 = re.findall('..', ethAddress)
                ethAdd2 = tuple(int('0x'+i, 16) for i in ethAdd1)
                ethsmp.set_ether_dhost(ethAdd2)
                ethsmp.set_ether_type(ETH_SMP_TYPE)
                ethsmp.contains(smpPacket)
                sock1.send(ethsmp.get_packet())

                return bytes11
           else:
               #construct a pdu to SDS
               sdsReq1 = SDSReq()
               tid = ''.join(random.choice(string.digits+'abcdef') for _ in range(8)) #highly random- can't repeat- supports 2^8 tid's
               tidb = tuple(int('0x'+i, 16) for i in re.findall('..',tid))
               sdsReq1.set_tid(tidb)
               sdsReq1.set_sid(tuple(ord(i) for i in re.findall('.',tab_smp[smpfd][1])))
               sdsReq1.set_role(tab_smp[smpfd][2])

               #ETH pdu
               eth = ImpactPacket.Ethernet()
               eth.set_ether_type(ETH_SDS_TYPE)
               eth.set_ether_shost(ETH_MY_MAC)
               eth.set_ether_dhost(ETH_SDS)
            
               eth.contains(sdsReq1)
            
               s = tab_smp[smpfd][0]
               print s
               s.bind(("eth0",0))
               s.send(eth.get_packet())
               
               p = open_live("eth0", 46+bytes1, False, 100)
               p.setfilter("ether src 40:40:40:40:40:39")
               p.loop(1,EthDecoder1)
    else:
        return -1

def EthDecoder1(hdr,data):
    eth = EthDecoder().decode(data)
    sdsResp = eth.child()
    str1 = sdsResp.__str__()
    
    print str1
    
    port = str1[-9:-5] + str1[-4:]
    ttl = str1[-14:-10] 
    ethAddress = str1[-29:-25]+str1[-24:-20]+str1[-19:-15]
    sid1 = str1[25:29]+str1[30:34]+str1[35:39]+ str1[40:44]+str1[65:69] #sid in hex
    role1 = int(str1[70:74], 16)
    tid = str1[15:19]+str1[20:24]

    print port, ttl, ethAddress, sid1, role1, tid
    if int('0x'+ttl, 16) > 0 : #checks for ttl expiry before sending
      sock1 = socket.socket()
      for key in tab_smp.keys():
          if tab_smp[key] == (sid1, role1):
              sock1 = tab_smp[key][0]
              print sock1
              break

      smpPacket = SMP()
      smpPacket.set_plen(bytes11)
      smpPacket.set_dport(int('0x'+port, 16))
      smpPacket.set_sport(SPORT)
      smpPacket.contains(ImpactPacket.Data(buf1))

      ethsmp = ImpactPacket.Ethernet()

      ethsmp.set_ether_shost(ETH_MY_MAC)

      ethAdd1 = re.findall('..', ethAddress)
      ethAdd2 = tuple(int('0x'+i, 16) for i in ethAdd1)
      ethsmp.set_ether_dhost(ethAdd2)
      ethsmp.set_ether_type(ETH_SMP_TYPE)
      ethsmp.contains(smpPacket)
      sock1.send(ethsmp.get_packet())

      return bytes11

def recvfrom_smp(smpfd, buf, bytes1, from1):
    if tab_smp.has_key(smpfd):
      from1.serviceID = 'zzzzz'+''.join(random.choice(string.ascii_lowercase) for _ in range(5)) #providing a ep structure to the remote peer
      from1.r = 'peer'
      buf1 = buf
      bytes11 = bytes1

      p = open_live("eth0", 100, False, 100)
      p.setfilter("ether src "+ETH_REMOTE_MAC1)
      p.loop(1, EthDecoder2)

def EthDecoder2(hdr, data):
    eth = EthDecoder().decode(data)
    smpPack = eth.child()
    str1 = smpPack.__str__()

    print "SMP Received: "+str1
    return bytes11


to = smp_ep()
to.r = 2
to.serviceID = 'ca4433b4ad'
s11 = socket_smp(to, 10)
print s11
sendto_smp(s11, 'abcd', 32, to)
    
    
    


            
        
        
    
    
    
    
    
    
