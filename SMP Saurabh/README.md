# SMP Demo
Assignment and project demonstrations of SMP Protocol

- test_pdu sends custom SMP packets by using libnet. Install libnet before running test_pdu.
- The input format for test_pdu is:	[version profile payload_len dstport srcport payload ip.proto incomplete stop] (without brackets)
  where version,profile,payload_len,dstport,srcport are values of SMP header fields; ip.proto is the value of protocol field of IP; incomplete is a flag which should be set when you wish to send incomplete packets and stop should be 0 for all lines except the last in the input file.
- A sample input file has been provided.
- For testing, do the following:
	- First, start the server.
	- Create an input file (similar to the one provided).
	- Execute test_pdu with input redirection from the input file.
	- Observe the error messages given by test_server.
- The expected error messages for the sample input file are as follows:
	Input:
		1 0 5 123456 500 hello 240 0 0
		0 2 5 123456 500 hello 240 0 0
		0 0 3 123456 500 hello 240 0 0
		0 0 5 123456 500 hello 240 0 0
		0 0 5 23456 500 hello 240 0 0
		0 0 5 123456 500 hello 240 1 0
		0 0 5 123456 500 hello 240 0 1
	test_server output:
		wrong version
		wrong profile
		payload_len does not match
		Size: 5
		Messege received: hello
		dstport does not match
		incomplete packet
		Size: 5
		Messege received: hello
