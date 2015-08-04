# WCFCommunication

这个主要是搭建了一个可以用于相互沟通的WCF服务与客户端

服务端与客户端共享Interface与Entity，并且沟通需要使用证书以及密码

新建证书使用如下命令：
`makecert.exe -sr LocalMachine -ss My -a sha1 -n CN=JJYService -sky exchange -pe`

证书生成后需要把客户端的密钥重新修改一下
