# INET-Vagrant-Demos
Assignment and project demonstrations of Internetworking Technologies course.

1. Use **sudo apt-get install vagrant** to get vagrant from the repository
2. Download the Nonce Demo folder from git
3. Navigate to the folder on the terminal, do a **vagrant up** **CAUTION: Make sure you have a working Internet connection before doing a **vagrant up**. If you are doing this for the first time, it would take about 15-20 minutes to download the 1 GB Ubuntu precise box from the Hashicorp repository. Make sure you have atleast 512 MB free in your RAM**
4. Open another Terminal window. Type **vagrant ssh** in both.
5. Navigate to /vagrant folder in both windows
6. Fire up the server on one window by saying: **sudo python server.py**
7. Fire up the client on the other window: **sudo python client.py**
8. Figure out what's happening!
9. When you are done, Ctrl+Z on the server - open another fresh Terminal, navigate to the repository folder, and do: **vagrant halt**
10. Congratulations, You have done the first Internetworking Demo!
