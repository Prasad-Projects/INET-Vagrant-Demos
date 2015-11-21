#!/bin/bash
#######################################################
#Script to start the HAProxy Demo - opens the Load Balancer terminal for display
#Inputs:
#Outputs:
#Author: Rachit Bhatia
#Date: 21/11/2015
#######################################################
if [ -f /usr/bin/vagrant -o -d ../../INET-Vagrant-Demos/ -o -d ~/.vagrant.d/boxes/hashicorp-VAGRANTSLASH-precise64/ ]
then
    echo "Something not installed, installing....."
    ../Installation_Script.bash
fi

cd LB
vagrant up
cd ../Server1
vagrant up
cd ../Server2
vagrant up
cd ../Server3
vagrant up

