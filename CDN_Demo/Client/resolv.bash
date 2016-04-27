#!/bin/bash
#################
#script to copy required DNS resolver configuration and restore it.
# To copy the given script, 
#		go to the Client directory and run from terminal
#		$chmod +x resolv.bash
# 		$./resolv.bash copy
# To restore the original configuration, 
#		go to the Client directory and run from terminal
# 		$./resolv.bash restore
################

if [ "$1" == "copy" ] 
then
sudo mv /etc/resolv.conf /etc/resolv.conf-backup
sudo cp resolv.conf /etc/resolv.conf
fi

if [ "$1" == "restore" ] 
then
sudo mv /etc/resolv.conf-backup /etc/resolv.conf
fi
