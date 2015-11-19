# DTN Demo
Assignment and project demonstrations of DTN Demo

1. The **dtn.conf** required in pdf **DTN_question_to_students.pdf** is provided.
2. Copy the **dtn-2.9.0**, **db-5.1.29**, and **oasys** folders in each of the Machines (Machine1, Machine2, Machine3).
3. Fire up the three machines using a **vagrant up** in 3 terminals. Keep a gap of about 1 minute between each **vagrant up**.
4. Three terminals will be opened up. Wait for the prompt to be displayed on your terminal. This can take upto 40 minutes if being done for the first time.
5. In the VirtualBox terminals for the 3 machines, navigate to /vagrant/dtn-2.9.0/. Type in sudo daemon/dtnd -c ../dtn.conf. This should display the % prompt. 
6. Say we want to send a message from Machine1 to Machine2. SSH into Machine1 by navigating to ~/INET-Vagrant-Demos/DTN\ Demo1/Machine1 and typing **vagrant ssh**.
7. In the Machine1 terminal navigate to **/vagrant/dtn-2.9.0/apps/dtnsend** folder. Type: **dtnsend -s dtn://mach1.dtn/1 -d dtn://mach2.dtn/2 -t m -p "mach1tomach2"**
8. Go to VM Machine2, and type in the dtn% prompt: **bundle list**. The sent message will be visible.
9. Now SSH into Machine2 by navigating to ~/INET-Vagrant-Demos/DTN\ Demo1/Machine2/ and typing **vagrant ssh**. Here navigate to **/vagrant/dtn-2.9.0/apps/dtnrecv**. Type in **dtnrecv dtn://mach2.dtn/2**. The message will be displayed. Use Ctrl-C to get the prompt back.
10. Now down the link between Machine1 and Machine2 by typing **link close link_one** and **link close link_alt** in the mach1 dtn% prompt, and send a message from Machine1 to Machine3 using the command in Step 7. Use **bundle list** on Machine3. What do you see? The message is not shown because it has not been able to escape the temporary storage of Machine1 due to the link being down. You can see this by typing **bundle list** on the mach1 dtn% prompt.
11. Now open any of the two links by typing **link open link_one** in the Machine1 prompt. Now again type **bundle list** on Machine3 prompt. The message is can be seen as an incoming bundle into Machine3.
12. When you are done, navigate to the folders ~/INET-Vagrant-Demos/Machine1 Machine2 & Machine3, type **vagrant halt** and press Enter.
