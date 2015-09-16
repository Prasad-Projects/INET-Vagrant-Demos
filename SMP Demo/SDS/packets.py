#!/usr/bin/python2.7
import impacket
from impacket import ImpactPacket
from impacket.ImpactPacket import ProtocolPacket, Header
SDS_SERV_LOC = "127.0.1.12"

class SMP(Header):
    def __init__(self, aBuffer=None):
        Header.__init__(self, 12)
        self.set_byte(0, 0)
        self.set_byte(1, 0)
        if(aBuffer):
            self.load_header(aBuffer)

    def get_version(self):
        return self.get_byte(0)
    
    def get_profile(self):
        return self.get_byte(1)

    def get_plen(self): #check for plen- shouldn't exceed the plen given
        return self.get_byte(2)
    def set_plen(self, value):
        self.set_word(2, value)

    def get_dport(self):
        return self.get_long(4)
    def set_dport(self, value):
        self.set_long(4, value)

    def get_sport(self):
        return self.get_long(8)
    def set_sport(self, value):
        self.set_long(8, value)

    def get_hsize(self):
        return 12

    def __str__(self):
        tmp_str = 'SMP %d -> %d' % (self.get_sport(), self.get_dport())
        if self.child():
            tmp_str += '\n' + self.child().__str__()
        return tmp_str
    
    def get_packet(self):
        return Header.get_packet(self)

class SDSReq(Header): #modify
    def __init__(self, aBuffer=None):
        Header.__init__(self, 12)
        self.set_byte(0, 0)
        self.set_byte(1, 0)
        self.set_word(2,12)
        if(aBuffer):
            self.load_header(aBuffer)

    def get_version(self):
        return self.get_byte(0)
    
    def get_rlength(self):
        return 12

    def get_tid(self):
        return self.get_bytes()[4:8]
    def set_tid(self, value):
        for i in range(0,4):
            self.set_byte(4+i, value[i])

    def get_sid(self):
        return self.get_bytes()[8:18]
    def set_sid(self, value):
        for i in range(0,10):
            self.set_byte(i + 8, value[i])

    def get_role(self):
        return self.get_word(18)
    def set_role(self, value):
        self.set_word(18, value)

    def __str__(self):
        tmp_str = 'SDSReq TID: %s SID: %s Role: %s' % (self.get_tid(), self.get_sid(), self.get_role())
        if self.child():
            tmp_str += '\n' + self.child().__str__()
        return tmp_str

    def get_packet(self):
        return Header.get_packet(self)

class SDSResponse(SDSReq):
    def __init__(self, aBuffer=None):
        Header.__init__(self, 12)
        self.set_byte(0, 0)
        self.set_byte(1, 0)
        self.set_word(2,24)
        if(aBuffer):
            self.load_header(aBuffer)
    def get_ethAddress(self):
        return self.get_bytes()[20:26]
    def set_ethAddress(self, value):
        for i in range(0,6):
            self.set_byte(i + 20, value[i])

    def get_ttl(self):
        return self.get_word(26)
    def set_ttl(self, value):
        self.set_word(26, value)

    def get_port(self):
        return self.get_long(28)
    def set_port(self, value):
        self.set_long(28, value)

    def get_rlength(self):
        return 24
    
    def __str__(self):
        tmp_str = 'SDSReq TID: %s SID: %s Role: %s EthAddress: %s TTL: %s Port: %s' % (self.get_tid(), self.get_sid(), self.get_role(), str(self.get_ethAddress()), str(self.get_ttl()), str(self.get_port()))
        if self.child():
            tmp_str += '\n' + self.child().__str__()
        return tmp_str

    
