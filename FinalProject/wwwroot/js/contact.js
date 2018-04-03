    let transportType = signalR.TransportType.WebSockets;
    let http = new signalR.HttpConnection(`http://${document.location.host}/lhh/livehelphub`, { transport: transportType });
    let connection = new signalR.HubConnection(http);
    connection.start();
 
    connection.on('Send', (name, message) => {
        if (name==""){
            name="Anonymous";
        }
        appendLine(message, name);    
    });

    function addE(){
        document.getElementById('send').addEventListener('click', event => {
            let message = document.getElementById('message').value;
            let name = document.getElementById('username').value;
            document.getElementById('message').value = '';
            
     
            connection.invoke('Send', name, message);   
            event.preventDefault();
        });
        
        $("#message").keyup(function(event) {
            if (event.keyCode === 13) {
                $("#send").click();
            }
        });
        $("#username").keyup(function(event) {
            if (event.keyCode === 13) {
                $("#send").click();
            }
        });
    }

    function wt(){
        if(document.getElementById('send')!=null){
            addE();
        }
        else{
            setTimeout(wt,100);
        }
    }
 
    
 
    function appendLine(line, name) {
        let li = document.createElement('li');
        li.innerText = name + ":" + line;
        document.getElementById('liveHelp').appendChild(li);
        //document.getElementById('layoutmessage').innerText="Message from " + name + ":" + line;
    };