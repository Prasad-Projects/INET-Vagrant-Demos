#!/usr/bin/python2.7
import pcapy
from pcapy import open_live, findalldevs
import impacket
from impacket import ImpactDecoder, ImpactPacket
from impacket.ImpactDecoder import EthDecoder

import sys
import string
from threading import Thread
import socket
import signal

#use time module to stop the execution if no reply is received for 10s

#use decode, encode to increment and deal with 4-bit ascii strings
#>>> hex(int('paul'.encode("hex"), 16) + 1)[2:].decode("hex")
#'paum'

#>>> "7061756c".decode("hex")
#'paul'

#>>> 'paul'.encode("hex")
#'7061756c'

def handle_alarm():
  print "Client not responding"
  sys.exit()

ETH_MY_MAC = 0x40,0x16,0x7e,0x9d,0xb5,0x78 #mac 40:16:7E:9D:B5:78

def main():
  signal.signal(signal.SIGALRM,lambda *args: handle_alarm())
  #build ethernet frame
  eth=ImpactPacket.Ethernet()
  eth.set_ether_type(0x88b5)
  eth.set_ether_shost(ETH_MY_MAC)
  eth.set_ether_dhost(ETH_MY_MAC)
  
  #build ip packet
  ip=ImpactPacket.IP()
  ip.set_ip_v(4)
  ip.set_ip_len(32)
  ip.set_ip_src("127.0.0.1")
  ip.set_ip_dst("127.0.0.1")
  
  #build UDP packet
  udp=ImpactPacket.UDP()
  udp.set_uh_sport(62000)
  udp.set_uh_dport(62001)
  udp.set_uh_ulen(12)
  
  inp1 = ''
  
  print "Client.... Port: "+str(udp.get_uh_sport())
  print "--------------------------------------------"
  
  while( len(inp1)!=4 ):
    inp1 = raw_input('Enter 4-bit ASCII nonce to send: ')
    if(len(inp1) != 4):
      print "Enter 4-bit ASCII"  
      
  payload=inp1
  udp.contains(ImpactPacket.Data(payload))
  
  ip.contains(udp)
  eth.contains(ip)
  
  device='lo'

  s=socket.socket(socket.AF_PACKET,socket.SOCK_RAW,socket.htons(0x88b5))
  s.bind((device,0))
  
  s.send(eth.get_packet())
  
  print "Sent: "+inp1
  
  receiveReply()
  
def receiveReply():
  p=open_live('lo',46,False,100)
  p.setfilter("udp")
  p.setfilter("src port 62001")
  signal.alarm(5)
  p.loop(1,EthDecoder1)
  
def EthDecoder1(hdr,data):
  eth = EthDecoder().decode(data)
  ip = eth.child()
  udp = ip.child()  
  
  print "Received: "+udp.get_data_as_string()
    
  
if __name__ == "__main__":
  main()  
  
