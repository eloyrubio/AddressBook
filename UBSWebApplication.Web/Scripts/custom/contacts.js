var Contacts = {

    init: function () {

        // removes backdrop from modals
        $.fn.modal.prototype.constructor.Constructor.DEFAULTS.backdrop = false;

        // attaches search event
        $("#search").keyup(function () {
            Contacts.search($("#search").val());
        });

        // opens edit modal
        $("#contactsTable").on("click", "tr", function () {

            // get values from row
            var row = $(this);
            var id = row.data("id");
            var firstName = row.find("td[id^=\"firstName\"]").text();
            var lastName = row.find("td[id^=\"lastName\"]").text();
            var street = row.find("td[id^=\"street\"]").text();
            var zip = row.find("td[id^=\"zip\"]").text();
            var country = row.find("td[id^=\"country\"]").text();
            var city = row.find("td[id^=\"city\"]").text();

            // set values in form
            Contacts.edit.fillIn(id, firstName, lastName, street, zip, country, city);

            // display modal
            $("#editContactModal").modal("show");
        });

        // delete a contact
        $("#deleteContact").click(function () {
            Contacts.delete.call($(Contacts.formSelectors.id).val());
        });

        // save a contact
        $("#saveContact").click(function () {
            Contacts.edit.save();
        });
    },

    search: function (query) {
        $.ajax({
            type: "GET",
            url: "Contacts/Contacts",
            contentType: "application/json; charset=utf-8",
            data: { query: query },
            dataType: "json",
            success: function (result) {
                Tables.main.empty();
                Tables.main.addRows(result);
            },
            error: function () {
                notifications.show("<b>Error:</b> contacts cannot be retrieved", "top", "center", "danger");
            }
        });
    },

    create: {
        onSuccess: function (result) {
            // close modal
            $("#createContactModal").modal("hide");

            // reset fields
            $("#createContactForm")[0].reset();

            // display notification
            notifications.show("<b>" + result.contact.FirstName + "</b> was added succesfully!", "top", "center", "success");

            // add contact to grid
            Tables.main.addRow(result.contact.Id,
                result.contact.FirstName,
                result.contact.LastName,
                result.contact.Street,
                result.contact.Zip,
                result.contact.Country,
                result.contact.City,
                result.contact.Image);

            // fade and highlight effect when adding contact
            Tables.main.highlight(result.contact.Id);
        },

        onFailure: function (result) {
            // display notification
            notifications.show("<b>Error:</b> <b>" + result.contact.FirstName + "</b> could not be created", "top", "center", "danger");
        }
    },

    formSelectors: {
        id: "#editContactForm #Id",
        firstName: "#editContactForm #FirstName",
        lastName: "#editContactForm #LastName",
        street: "#editContactForm #Street",
        zip: "#editContactForm #Zip",
        country: "#editContactForm #Country",
        city: "#editContactForm #City"
    },

    edit: {
        fillIn: function (id, firstName, lastName, street, zip, country, city) {
            $(Contacts.formSelectors.id).val(id);
            $(Contacts.formSelectors.firstName).val(firstName);
            $(Contacts.formSelectors.lastName).val(lastName);
            $(Contacts.formSelectors.street).val(street);
            $(Contacts.formSelectors.zip).val(zip);
            $(Contacts.formSelectors.country).val(country);
            $(Contacts.formSelectors.city).val(city);
        },

        onSuccess: function (result) {
            // close modal
            $("#editContactModal").modal("hide");

            // display notification
            notifications.show("<b>" + result.contact.FirstName + " " + result.contact.LastName + "</b> was updated succesfully!", "top", "center", "success");

            // update contact on grid
            Tables.main.updateRow(result.contact.Id,
                result.contact.FirstName,
                result.contact.LastName,
                result.contact.Street,
                result.contact.Zip,
                result.contact.Country,
                result.contact.City);

            // highlight updated row
            Tables.main.highlight(result.contact.Id);
        },

        onFailure: function (result) {
            // display notification
            notifications.show("<b>Error:</b>  <b>" + result.contact.FirstName + " " + result.contact.LastName + "</b> could not be updated", "top", "center", "danger");
        }
    },

    delete: {
        call: function (id) {
            $.ajax({
                type: "GET",
                url: "Contacts/Delete",
                contentType: "application/json; charset=utf-8",
                data: { id: id },
                dataType: "json",
                success: function (result) {
                    Contacts.delete.onSuccess(result);
                },
                error: function (result) {
                    Contacts.delete.onFailure(result);
                }
            });
        },

        onSuccess: function (result) {
            // close modal
            $("#editContactModal").modal("hide");
            
            // display notification
            notifications.show("<b>" + result.contact.FirstName + " " + result.contact.LastName + "</b> was deleted succesfully!", "top", "center", "success");

            // remove row from grid
            Tables.main.deleteRow(result.contact.Id);
        },

        onFailure: function () {
            // display notification
            notifications.show("<b>Error:</b> Contact could not be deleted", "top", "center", "danger");
        }
    }
};

(function () {
    Contacts.init();
})();