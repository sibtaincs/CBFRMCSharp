var FormValidation = function () {

   
  

   
    var OnsiteValidation = function () {
        // for more info visit the official plugin documentation: 
        // http://docs.jquery.com/Plugins/Validation
        var form1 = $('#OnsiteValidation');
        var error1 = $('.alert-danger', form1);
        var success1 = $('.alert-success', form1);

        form1.validate({
            errorElement: 'span', //default input error message container
            errorClass: 'help-block help-block-error', // default input error message class
            focusInvalid: false, // do not focus the last invalid input
            ignore: "", // validate all fields including form hidden input
            messages: {
                //ddlStatus: {
                //    required: jQuery.validator.format("Select Report Status")

                //},
                ddlCountry: {
                    required: jQuery.validator.format("Select Country")

                },
                ddlCity: {
                    required: jQuery.validator.format("Select City")

                },
                txtInciDate: {
                    required: jQuery.validator.format("Input Incident Date")
                },
                IncidentTime: {
                    required: jQuery.validator.format("Input Incident Time")
                },
                txtDescRemaining: {
                    required: jQuery.validator.format("Input Incident Description")
                },
                FinancialLoss: {
                    required: jQuery.validator.format("Input Financial Loss"),
                    number: jQuery.validator.format("Input Only Numeric Values")
                },
                IncidentType: {
                    required: jQuery.validator.format("Select Incident Type")
                },

                Latitude: {
                    required: jQuery.validator.format("Input Latitude"),
                    number: jQuery.validator.format("Latitude Must be Numeric Value")
                   
                },
                Longitude: {

                    required: jQuery.validator.format("Input Longitude"),
                    number: jQuery.validator.format("Longitude Must be Numeric Value")
                }
            },
            rules: {

                //ddlStatus: {
                //    required: true
                //},
                ddlCountry: {
                    required: true
                },
                ddlCity: {
                    required: true
                },
                txtInciDate: {

                    required: true
                },
                IncidentTime: {

                    required: true
                },
                txtDescRemaining: {
                    required: true
                },
                FinancialLoss: {
                    required: true,
                    number: true
                },
                IncidentType: {
                    required: true
                },
                Latitude: {

                    number: true
                },

                Longitude: {
                    number: true
                
                }
            },

            invalidHandler: function (event, validator) { //display error alert on form submit              
                success1.hide();
                error1.show();
                App.scrollTo(error1, -200);
            },

            errorPlacement: function (error, element) {
                if (element.is(':checkbox')) {
                    error.insertAfter(element.closest(".md-checkbox-list, .md-checkbox-inline, .checkbox-list, .checkbox-inline"));
                } else if (element.is(':radio')) {
                    error.insertAfter(element.closest(".md-radio-list, .md-radio-inline, .radio-list,.radio-inline"));
                } else {
                    error.insertAfter(element); // for other inputs, just perform default behavior
                }
            },

            highlight: function (element) { // hightlight error inputs
                $(element)
                    .closest('.form-group').addClass('has-error'); // set error class to the control group
            },

            unhighlight: function (element) { // revert the change done by hightlight
                $(element)
                    .closest('.form-group').removeClass('has-error'); // set error class to the control group
            },

            success: function (label) {
                label
                    .closest('.form-group').removeClass('has-error'); // set success class to the control group
            },

            submitHandler: function (form) {
                success1.show();
                error1.hide();
                form[0].submit();
            }
        });
    }

   
 

    return {
        //main function to initiate the module
        init: function () {

          
            OnsiteValidation();

        }

    };

}();

jQuery(document).ready(function() {
    FormValidation.init();
});