function like(post_id) {
    $.ajax({
        url: yourApp.Urls.editUserUrl,
        data: { post_id: post_id},
        datatype: 'json',
        success: function (data) {
            var likes = document.getElementById(post_id);
            var number = likes.innerHTML;
            number++;
            likes.innerHTML = number;
        }
    });
}