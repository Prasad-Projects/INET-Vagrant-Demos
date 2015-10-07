# DTN Demo
Assignment and project demonstrations of DTN Demo

1. The **dtn.conf** required in pdf **DTN_question_to_students.pdf** is provided.
2. Copy the **dtn-2.9.0**, **db-5.1.29**, and **oasys** folders in each of the Machines (Machine1, Machine2, Machine3).
3. Fire up the three machines using a **vagrant up** in 3 terminals.
4. Three terminals will be opened up
5. Say we want to send a message from Machine1 to Machine2.
6. In the host computer's terminal navigate to **dtn-2.9.0/apps/dtnsend** folder. Type: **dtnsend -s dtn://mach1.dtn/1 -d dtn://mach2.dtn/2 -t m -p "mach1tomach2"**
7. Go to VM Machine2, and type in the dtn% prompt: **bundle list**. The sent message will be visible.
8. Navigate to **dtn-2.9.0/apps/dtnrecv**. Type in **dtnrecv dtn://mach2.dtn/2**. The message will be displayed.
9. Now down the link between Machine1 and Machine2, and send a message from Machine1 to Machine3. Use bundle list on Machine3. What do you see?
