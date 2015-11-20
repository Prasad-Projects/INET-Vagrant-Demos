#!/bin/bash

wget https://releases.hashicorp.com/vagrant/1.7.4/vagrant_1.7.4_x86_64.deb
dpkg -i vagrant_1.7.4_x86_64.deb
git clone https://github.com/prasadtalasila/INET-Vagrant-Demos.git
vagrant box add hashicorp/precise64
cd INET-Vagrant-Demos/DTN\ Demo1/Machine1
vagrant up
cd ../Machine2
vagrant up
cd ../Machine3
vagrant up
