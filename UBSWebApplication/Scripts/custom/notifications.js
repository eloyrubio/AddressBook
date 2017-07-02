var notifications = {

    // color:'info','success','warning','danger'
    show: function (message, from, align, color) {
        $.notify({
            icon: "ti-user",
            message: message
        }, {
            type: color,
            timer: 1000,
            placement: {
                from: from,
                align: align
            }
        });
    }
};