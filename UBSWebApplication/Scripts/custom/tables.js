var Tables = {
    main: {
        empty: function () {
            $("#contactsTable tbody").empty();
        },

        addRow: function (id, firstName, lastName, street, zip, country, city, image) {
            $("#contactsTable tbody").prepend("<tr class=\"clickable-row\" data-id=\"" + id + "\">" +
                "<td id=\"image" + id + "\"><img class=\"img-circle\" src=\" " + image + "\" height=\"80\" width=\"80\"></td>" +
                "<td id=\"firstName" + id + "\"><b>" + firstName + "</b></td>" +
                "<td id=\"lastName" + id + "\"><b>" + lastName + "</b></td>" +
                "<td id=\"street" + id + "\">" + street + "</td>" +
                "<td id=\"zip" + id + "\">" + zip + "</td>" +
                "<td id=\"country" + id + "\">" + country + "</td>" +
                "<td id=\"city" + id + "\">" + city + "</td>" +
                "</tr >");
        },

        addRows: function (contacts) {
            $.each(contacts, function (i, contact) {
                Tables.main.addRow(contact.Id,
                    contact.FirstName,
                    contact.LastName,
                    contact.Street,
                    contact.Zip,
                    contact.Country,
                    contact.City,
                    contact.Image);
            });
        },

        updateRow: function (id, firstName, lastName, street, zip, country, city) {
            $("#firstName" + id).html("<b>" + firstName + "</b>");
            $("#lastName" + id).html("<b>" + lastName + "</b>");
            $("#street" + id).html(street);
            $("#zip" + id).html(zip);
            $("#country" + id).html(country);
            $("#city" + id).html(city);
        },

        highlight: function (id) {
            $("#contactsTable tr").removeClass("warning");
            $("#contactsTable tr[data-id='" + id + "']").addClass("warning");
            $("#contactsTable tr[data-id='" + id + "']").hide().fadeIn(800);
        },

        deleteRow: function (id) {
            // delete row from grid
            $("#contactsTable tr[data-id='" + id + "']").fadeOut("slow", function () {
                $(this).remove();
            });
        }
    }
};