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
    echo "Vagrant installed"
else
    echo "Vagrant not installed, installing ....."
    wget -c https://releases.hashicorp.com/vagrant/1.7.4/vagrant_1.7.4_x86_64.deb
    sudo dpkg -i vagrant_1.7.4_x86_64.deb
fi
if [ -d ../INET-Vagrant-Demos/ ]
then
    echo "Directory cloned from git"
    chmod +x *.bash
    cd SMP_Demo
    chmod +x *.bash
    cd ../Nonce_Demo
    chmod +x *.bash
    cd ../DTN_Demo
    chmod +x *.bash
    cd ../HAProxy_Demo
    chmod +x *.bash
    cd ..   
else
    echo "Directory not cloned from git, doing ....."
    git clone https://github.com/prasadtalasila/INET-Vagrant-Demos.git
    cd ./INET-Vagrant-Demos/
    chmod +x *.bash
    cd SMP_Demo
    chmod +x *.bash
    cd ../Nonce_Demo
    chmod +x *.bash
    cd ../DTN_Demo
    chmod +x *.bash
    cd ../HAProxy_Demo
    chmod +x *.bash
    cd ..    
fi
if [ -d ~/.vagrant.d/boxes/hashicorp-VAGRANTSLASH-precise64/ ]
then
    echo "Ubuntu Box installed" 
else
    echo "Ubuntu Box not installed, downloading & installing ......"
    vagrant box add hashicorp/precise64
fi
