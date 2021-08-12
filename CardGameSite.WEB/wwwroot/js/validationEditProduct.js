$(document).ready(function () {
    $("#prform").validate({
        rules: {
            prname: {
                required: true,
                minlength: 3
            }
        },
        messages: {
            prname: {
                required: "Это поле обязательно для заполнения",
                minlength: "Мин. длина 3 символа"
            }
        }
    });
});
