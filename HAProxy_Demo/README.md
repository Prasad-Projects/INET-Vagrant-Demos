1. Up the Load Balancer and the three Servers by going to ~/INET-Vagrant-Demos/LB , Server1 , Server2 & Server3 and typing ** vagrant up**
2. Now open 192.168.1.10/gardenwalkthrough in your browser. Also in another tab open up 192.168.1.10:1936/haproxy?stats
3. Now as you click on the various links on the site, have a look at the stats, the Load Balancer distributes the connections between the three servers
4. You can also SSH into the Load Balancer- navigate to ~/INET-Vagrant-Demos/LB and type in **vagrant ssh**
5. Now open up the configuration file - /etc/haproxy/haproxy.cfg, change the balance to leastconn or roundrobin and observe the stats
