#!/bin/bash
#######################################################
#Script to start the DTN Demo
#Inputs:
#Outputs:
#Author: Rachit Bhatia
#Date: 21/11/2015
#######################################################
if [ -f /usr/bin/vagrant ]
then
    ../Installation_Script.bash
fi
if [ -d ../../INET-Vagrant-Demos/ ]
then
    ../Installation_Script.bash
fi
if [ -d ~/.vagrant.d/boxes/hashicorp-VAGRANTSLASH-precise64/ ]
then
    ../Installation_Script.bash
fi

if [ -d Machine1/db/ ]
then
    rm -rf Machine1/db/
fi

if [ -d Machine1/bundles/ ]
then
    rm -rf Machine1/bundles/
fi

if [ -d Machine1/.vagrant/ ]
then
    rm -rf Machine1/.vagrant/
fi

if [ -d Machine3/db/ ]
then
    rm -rf Machine3/db/
fi

if [ -d Machine3/bundles/ ]
then
    rm -rf Machine3/bundles/
fi

if [ -d Machine3/.vagrant/ ]
then
    rm -rf Machine3/.vagrant/
fi

if [ -d Machine2/db/ ]
then
    rm -rf Machine2/db/
fi

if [ -d Machine2/bundles/ ]
then
    rm -rf Machine2/bundles/
fi

if [ -d Machine2/.vagrant/ ]
then
    rm -rf Machine2/.vagrant/
fi

cd Machine1
vagrant up
cd ../Machine2
vagrant up
cd ../Machine3
vagrant up
