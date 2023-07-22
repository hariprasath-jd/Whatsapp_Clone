
function CloseChat() {
    document.getElementById('container').style.display = "none";
    document.getElementById('newpartial').style.display = "block";
}


$(document).ready(function () {

    //this ajax method is for 
    $('#formsubmit').submit(function (event) {
        event.preventDefault();

        //get the parameters and data
        var form = new FormData();

        var message = $('#messagebox').val();
        var rec_id = sessionStorage.getItem('Rec_Id');
        var date = new Date();
        var time = date;

        form.append('day', time);
        form.append('Content', message);
        form.append('rec_id', rec_id);


        //passing the data to the ajax method
        $.ajax({

            url: '/SendMessage',
            type: 'POST',
            data: form,
            contentType: false,
            processData: false,

            success: function (response) {
                if (response != null) {

                    //to create a new in the text body
                    let sent_para = document.createElement("p");
                    sent_para.classList = "small p-2 me-3 mb-1 text-white rounded-3 bg-primary";
                    sent_para.innerHTML = message;
                    document.getElementById('sent_message').appendChild(sent_para);

                }
                else {
                    alert('falied');
                }
            },

            error: function (response) {
                alert('error message' + JSON.stringify(response));
            }
        });
    });
});


function makeNewChat(btn)
{
    //btn.
}


$(document).ready(function () {

    $("#searchbar").on('input', function () {
        let data = $("#searchbar").val();
        document.getElementById("contactarea").innerHTML = "";
        $.ajax(
            {
                url: "/SearchContact",
                type: 'POST',
                data: data.trim().replace("@[a-zA-Z0-9][a-zA-Z0-9.-]+(.[a-z]{2,}|.[0-9]{1,}", " "),
                contentType: "text",
                success: function (response) {
                    console.clear()
                    for (j = 0; j < response.length; j++) {
                        let link = document.createElement('button');
                        link.classList = "list-group-item list-group-item-action py-3 lh-sm";
                        link.addEventListener("click",
                            function () {
                                makeNewChat(this);
                            }
                        );

                        link.id = "link_" + j;

                        let innerdiv = document.createElement('div');
                        innerdiv.classList = "d-flex w-100 align-items-center justify-content-between";
                        innerdiv.id = "innerdiv_" + j;

                        let strong = document.createElement('strong');
                        strong.classList = "mb-1";
                        strong.innerHTML = response[j].Name.toString();

                        let small = document.createElement('small');
                        small.classList = "text-body-secondary";
                        small.innerHTML = response[j].Content.toString();

                        let chatbtn = document.createElement('button');
                        chatbtn.className = "btn btn-success"

                        document.getElementById('contactarea').appendChild(link);
                        document.getElementById('link_' + j).appendChild(innerdiv);
                        document.getElementById('innerdiv_' + j).appendChild(strong);
                        document.getElementById('innerdiv_' + j).appendChild(small);
                        //console.log(response[j].Name.toString() + ' ' + response[j].Content);

                    }
                },
                error: function () {
                    $("#result").val() = 'error message';
                }
            }
        );
    });


});




//function to load chat data
function show(btn) {
    //clearing the last data
    document.getElementById('recivied_message').innerHTML = "";
    document.getElementById('sent_message').innerHTML = "";
    document.getElementById('newpartial').style.display = "none";

    //retriving id for data retrival
    var idt = btn.id;
    var n = idt.substr(idt.length - 1, 1);
    var containerid = "container";


    var name = document.getElementById("contact_" + n).innerText;  //getting contact name

    sessionStorage.setItem('Rec_Id', n);   //this line is foe the receiver id to pass the message during the message submission

    document.getElementById('container').style.display = "block";  //to make the block visible


    //ajax method
    $(document).ready(function () {
        $.ajax({
            //parameters for ajax request
            url: '/FetchChat?RId=' + n,
            type: 'POST',
            data: n.toString(),
            contentType: 'text',
            datatype: 'json',
            processData: false,

            success: function (response) {
                if (response != null) {


                    //loop to get all recived and sent mesages of the user
                    for (j = 0; j < response.length; j++) {

                        //to split the data according the type of messages
                        for (i = 0; i < response[j]["Content"].length; i++) {

                            // this line is for to fetch contact name of the user
                            document.getElementById('nameholder').innerHTML = name;

                            //var chats = new Array();
                            //chats = response[j]["time"][i]

                            //console.log(chats);


                            //to append in the received div as received message
                            if (response[j]["Type"] == "Received") {

                                //create a element to append
                                let rec_para = document.createElement("p");
                                rec_para.classList = "small p-2 ms-3 mb-1 rounded-3";
                                rec_para.style = "background-color: #f5f6f7;color:#252525;";
                                rec_para.innerHTML = response[j]["Content"][i];

                                //append the child to parent node
                                document.getElementById('recivied_message').appendChild(rec_para);
                            }
                            //to append in the sent div as sent message
                            else {
                                //create a element to append
                                let sent_para = document.createElement("p");
                                sent_para.classList = "small p-2 me-3 mb-1 text-white rounded-3 bg-primary";
                                sent_para.innerHTML = response[j]["Content"][i];

                                //append the child to parent node
                                document.getElementById('sent_message').appendChild(sent_para);
                            }
                        }
                    }
                }
                else {
                    console.log('falied requsert :' + response);
                }
            },
            error: function (respose) {
                console.log('error message :' + respose);
            }
        });
    });


}