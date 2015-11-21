#!/bin/bash
#######################################################
#Script to start the Nonce Demo - requires two SSHed terminals
#Inputs:
#Outputs:
#Author: Rachit Bhatia
#Date: 21/11/2015
#######################################################
if [ -f /usr/bin/vagrant -o -d ../../INET-Vagrant-Demos/ -o -d ~/.vagrant.d/boxes/hashicorp-VAGRANTSLASH-precise64/ ]
then
    echo "Something not installed, installing....."
    cd ..
    ./Installation_Script.bash
    cd Nonce_Demo
fi

vagrant up
