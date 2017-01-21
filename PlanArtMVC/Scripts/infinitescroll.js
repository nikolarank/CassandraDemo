$(window).scroll(function () {
    if ($(window).scrollTop() + $(window).height() == $(document).height()) {
        FetchDataFromServer();
    }
});


var skipCount = 5; // start at 6th record (assumes first 5 included in initial view)
var takeCount = 5; // return new 5 records
var hasMoreRecords = true;

function FetchDataFromServer() {
    if (!hasMoreRecords) {
        return;
    }
    $.ajax({
        url: yourApp1.Urls.editUserUrl,
        data: { email: email, skipCount: skipCount, takeCount: takeCount },
        datatype: 'json',
        success: function (data) {
            if (data.Count < 5) {
                hasMoreRecords = false; // signal no more records to display
            }
            $.each(data.items, function (index, item) {
                var obj = jQuery.parseJSON(item);
                var container = $('<div></div>', {
                    class : 'w3-container w3-card-2 w3-white w3-round w3-margin cont'
                });
                var br = $("<br />");
                container.append(br);

                var img = $('<img />', {
                    src: localhost + "/Content/profilePictures/" + obj.profilepic,
                    class: 'w3-left w3-margin-right',
                    alt: 'Avatar',
                    style: 'width:60px'
                });
                container.append(img);
                var date = eval(("new " + obj.time).replace(/\//g, ""));
                var span = $('<span></span>', {
                    class: 'w3-right w3-opacity',
                    text: date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate() + " " + date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds()
                });
                container.append(span);

                var h4 = $('<h4></h4',{
                    text: obj.firstname + obj.lastname
                });
                container.append(h4);

                var hr = $('<hr>', {
                    class: "w3-clear"
                });
                container.append(hr);

                var p = $('<p></p>', {
                    text: obj.text
                });
                container.append(p);

                var sl = $('<div></div>', {
                    class: 'w3-content w3-display-container'
                });
                container.append(sl);

                if (obj.images)
                {

                    for (var i = 0; i < obj.images.length; i++) {
                        if (i > 0) {
                            var img2 = $('<img />', {
                                src: localhost + "/Content/postedPictures/" + obj.images[i],
                                class: obj.post_id,
                                alt: 'Avatar',
                                style: 'width:100%'
                            }).css("display", "none");
                        }
                        else {
                            var img2 = $('<img />', {
                                src: localhost + "/Content/postedPictures/" + obj.images[i],
                                class: obj.post_id,
                                alt: 'Avatar',
                                style: 'width:100%'
                            });
                        }
                        sl.append(img2);
                    }

                    if (obj.images.length > 1) {
                        var a = $('<a></a>', {
                            class: 'w3-btn-floating w3-display-left',
                            onclick: 'plusDivs(-1,' + '\'' + obj.post_id + '\'' + ')',
                            text: '<'
                        });
                        sl.append(a);

                        var a1 = $('<a></a>', {
                            class: 'w3-btn-floating w3-display-right',
                            onclick: 'plusDivs(1,' + '\'' + obj.post_id + '\'' + ')',
                            text: '>'
                        });
                        sl.append(a1);
                    }

                    
                }
                    

                    var br2 = $('<br />');
                    container.append(br2);

                    var a = 0;
                    if(obj.likes)
                        a = obj.likes
                    var p = $('<p></p>', {
                        id: obj.post_id,
                        text: a
                    });
                    container.append(p);

                    var br3 = $('<br />');
                    container.append(br3);

                    var button = $('<button></button>', {
                        onclick: 'like(' +  '\'' + obj.post_id + '\'' + ' , \'' + obj.email + '\')',
                        class: 'w3-btn w3-theme-d1 w3-margin-bottom',
                        text: 'Like'
                    });

                    container.append(button);
                
                $("#result").append(container);
            });
            skipCount += (takeCount + 1); // update for next iteration
        },
        error: function () {
            alert("error");
        }
    });
}
