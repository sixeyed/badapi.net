
To run the Proxy Endpoint tests locally, you will need to set up these endpoints in your hosts file:

127.0.0.1	badapi.local
127.0.0.1	transient.badapi.local
127.0.0.1	permanent.badapi.local
127.0.0.1	200.badapi.local
127.0.0.1	400.badapi.local
127.0.0.1	409.badapi.local
127.0.0.1	403.badapi.local
127.0.0.1	500.badapi.local
127.0.0.1	404.badapi.local
127.0.0.1	503.badapi.local
127.0.0.1	401.badapi.local

And set your IIS Website, badapi.local, to have bindings for all the above.