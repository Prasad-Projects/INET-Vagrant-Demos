#!/bin/bash
#######################################################
#Script to install basic dependencies
#Inputs:
#Outputs:
#Author: Rachit Bhatia
#Date: 21/11/2015
#######################################################
if [ -f /usr/bin/vagrant ]
then
    echo "Vagrant not installed, installing ....."
    wget https://releases.hashicorp.com/vagrant/1.7.4/vagrant_1.7.4_x86_64.deb
    dpkg -i vagrant_1.7.4_x86_64.deb
fi
if [ -d ../INET-Vagrant-Demos/ ]
then
    echo "Directory not cloned from git, doing ....."
    git clone https://github.com/prasadtalasila/INET-Vagrant-Demos.git
fi
if [ -d ~/.vagrant.d/boxes/hashicorp-VAGRANTSLASH-precise64/ ]
then 
    echo "Ubuntu Box not installed, downloading & installing ......"
    vagrant box add hashicorp/precise64
fi
