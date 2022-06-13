var FormValidation = function () {


    // advance validation
    var handleValidation3 = function () {
        // for more info visit the official plugin documentation: 
        // http://docs.jquery.com/Plugins/Validation

        var form3 = $('#sss');
        var error3 = $('.alert-danger', form3);
        var success3 = $('.alert-success', form3);

        //IMPORTANT: update CKEDITOR textarea with actual content before submit
        form3.on('submit', function () {
            for (var instanceName in CKEDITOR.instances) {
                CKEDITOR.instances[instanceName].updateElement();
            }
        })

        form3.validate({
            errorElement: 'span', //default input error message container
            errorClass: 'help-block help-block-error', // default input error message class
            focusInvalid: false, // do not focus the last invalid input
            ignore: "", // validate all fields including form hidden input
            rules: {


                SDate: {
                    required: true

                },

                EDate: {
                    required: true
                },

                StatusID: {
                    required: true

                },
                TypeID: {
                    required: true

                },

                CountryID: {
                    required: true

                },
                RefIncidentViewLevelID: {
                    required: true


                },
                RefCategoryID: {

                    required: true
                },
                IncidentQCategoryID: {
                    required: true
                }

            },

            messages: { // custom messages for radio buttons and checkboxes
                SDate: {
                    required: "From Date Required"
                },
                SDate: {
                    EDate: "To Date Required"
                },
                IncidentQCategoryID: {
                    required: "Please select  at least One Incident Category",
                    minlength: jQuery.validator.format("Please select  at least {0} types of Service")
                }
            },

            errorPlacement: function (error, element) { // render error placement for each input type
                if (element.parents('.mt-radio-list') || element.parents('.mt-checkbox-list')) {
                    if (element.parents('.mt-radio-list')[0]) {
                        error.appendTo(element.parents('.mt-radio-list')[0]);
                    }
                    if (element.parents('.mt-checkbox-list')[0]) {
                        error.appendTo(element.parents('.mt-checkbox-list')[0]);
                    }
                } else if (element.parents('.mt-radio-inline') || element.parents('.mt-checkbox-inline')) {
                    if (element.parents('.mt-radio-inline')[0]) {
                        error.appendTo(element.parents('.mt-radio-inline')[0]);
                    }
                    if (element.parents('.mt-checkbox-inline')[0]) {
                        error.appendTo(element.parents('.mt-checkbox-inline')[0]);
                    }
                } else if (element.parent(".input-group").size() > 0) {
                    error.insertAfter(element.parent(".input-group"));
                } else if (element.attr("data-error-container")) {
                    error.appendTo(element.attr("data-error-container"));
                } else {
                    error.insertAfter(element); // for other inputs, just perform default behavior
                }
            },

            invalidHandler: function (event, validator) { //display error alert on form submit   
                success3.hide();
                error3.show();
                App.scrollTo(error3, -200);
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
                success3.show();
                error3.hide();
                form[0].submit(); // submit the form
            }

        });

        //apply validation on select2 dropdown value change, this only needed for chosen dropdown integration.
        $('.select2me', form3).change(function () {
            form3.validate().element($(this)); //revalidate the chosen dropdown value and show error or success message for the input
        });

        //initialize datepicker
        $('.date-picker').datepicker({
            rtl: App.isRTL(),
            autoclose: true
        });
        $('.date-picker .form-control').change(function () {
            form3.validate().element($(this)); //revalidate the chosen dropdown value and show error or success message for the input 
        })
    }
    var EmployeeValidations = function () {
        // for more info visit the official plugin documentation: 
        // http://docs.jquery.com/Plugins/Validation

        var form2 = $('#IncidentSearchForm');
        var error2 = $('.alert-danger', form2);
        var success2 = $('.alert-success', form2);

        form2.validate({
            errorElement: 'span', //default input error message container
            errorClass: 'help-block help-block-error', // default input error message class
            focusInvalid: false, // do not focus the last invalid input
            ignore: "",  // validate all fields including form hidden input
            rules: {


                SDate: {
                    required: true

                },

                EDate: {
                    required: true
                },

                Title: {
                    required: true

                },
                //TypeID: {
                //    required: true

                //},

                //CountryID: {
                //    required: true

                //},
                //RefIncidentViewLevelID: {
                //    required: true


                //},
                //RefCategoryID: {

                //    required: true
                //},
                IncidentQCategoryID: {
                    required: true
                }

            },

            messages: { // custom messages for radio buttons and checkboxes
                SDate: {
                    required: "From Date Required"
                },
                SDate: {
                    EDate: "To Date Required"
                },
                IncidentQCategoryID: {
                    required: "Please select  at least One Incident Category",
                    minlength: jQuery.validator.format("Please select  at least {0} types of Service")
                }
            },


            invalidHandler: function (event, validator) { //display error alert on form submit              
                success2.hide();
                error2.show();
                App.scrollTo(error2, -200);
            },

            errorPlacement: function (error, element) { // render error placement for each input type
                var icon = $(element).parent('.input-icon').children('i');
                icon.removeClass('fa-check').addClass("fa-warning");
                icon.attr("data-original-title", error.text()).tooltip({ 'container': 'body' });
            },

            highlight: function (element) { // hightlight error inputs
                $(element)
                    .closest('.form-group').removeClass("has-success").addClass('has-error'); // set error class to the control group   
            },

            unhighlight: function (element) { // revert the change done by hightlight

            },

            success: function (label, element) {
                var icon = $(element).parent('.input-icon').children('i');
                $(element).closest('.form-group').removeClass('has-error').addClass('has-success'); // set success class to the control group
                icon.removeClass("fa-warning").addClass("fa-check");


            },

            submitHandler: function (form) {
                success2.show();
                error2.hide();

                form[0].submit(); // submit the form

                

            }
        });


    }

    var RoleValidation = function () {
        // for more info visit the official plugin documentation: 
        // http://docs.jquery.com/Plugins/Validation

        var form2 = $('#RoleValidation');
        var error2 = $('.alert-danger', form2);
        var success2 = $('.alert-success', form2);

        form2.validate({
            errorElement: 'span', //default input error message container
            errorClass: 'help-block help-block-error', // default input error message class
            focusInvalid: false, // do not focus the last invalid input
            ignore: "",  // validate all fields including form hidden input
            rules: {


                Description: {
                    required: true

                }

             

            },

            messages: { // custom messages for radio buttons and checkboxes
                Description: {
                    required: "Role Required"
                }
                
            },


            invalidHandler: function (event, validator) { //display error alert on form submit              
                success2.hide();
                error2.show();
                App.scrollTo(error2, -200);
            },

            errorPlacement: function (error, element) { // render error placement for each input type
                var icon = $(element).parent('.input-icon').children('i');
                icon.removeClass('fa-check').addClass("fa-warning");
                icon.attr("data-original-title", error.text()).tooltip({ 'container': 'body' });
            },

            highlight: function (element) { // hightlight error inputs
                $(element)
                    .closest('.form-group').removeClass("has-success").addClass('has-error'); // set error class to the control group   
            },

            unhighlight: function (element) { // revert the change done by hightlight

            },

            success: function (label, element) {
                var icon = $(element).parent('.input-icon').children('i');
                $(element).closest('.form-group').removeClass('has-error').addClass('has-success'); // set success class to the control group
                icon.removeClass("fa-warning").addClass("fa-check");


            },

            submitHandler: function (form) {
                success2.show();
                error2.hide();

                form[0].submit(); // submit the form



            }
        });


    }
    var CountryValidation = function () {
        // for more info visit the official plugin documentation: 
        // http://docs.jquery.com/Plugins/Validation

        var form2 = $('#CountryValidation');
        var error2 = $('.alert-danger', form2);
        var success2 = $('.alert-success', form2);

        form2.validate({
            errorElement: 'span', //default input error message container
            errorClass: 'help-block help-block-error', // default input error message class
            focusInvalid: false, // do not focus the last invalid input
            ignore: "",  // validate all fields including form hidden input
            rules: {


                Country: {
                    required: true

                }



            },

            messages: { // custom messages for radio buttons and checkboxes
                Country: {
                    required: "Country Required"
                }

            },


            invalidHandler: function (event, validator) { //display error alert on form submit              
                success2.hide();
                error2.show();
                App.scrollTo(error2, -200);
            },

            errorPlacement: function (error, element) { // render error placement for each input type
                var icon = $(element).parent('.input-icon').children('i');
                icon.removeClass('fa-check').addClass("fa-warning");
                icon.attr("data-original-title", error.text()).tooltip({ 'container': 'body' });
            },

            highlight: function (element) { // hightlight error inputs
                $(element)
                    .closest('.form-group').removeClass("has-success").addClass('has-error'); // set error class to the control group   
            },

            unhighlight: function (element) { // revert the change done by hightlight

            },

            success: function (label, element) {
                var icon = $(element).parent('.input-icon').children('i');
                $(element).closest('.form-group').removeClass('has-error').addClass('has-success'); // set success class to the control group
                icon.removeClass("fa-warning").addClass("fa-check");


            },

            submitHandler: function (form) {
                success2.show();
                error2.hide();

                form[0].submit(); // submit the form



            }
        });


    }
    var LPage = function () {
        // for more info visit the official plugin documentation: 
        // http://docs.jquery.com/Plugins/Validation

        var form2 = $('#LPage');
        var error2 = $('.alert-danger', form2);
        var success2 = $('.alert-success', form2);

        form2.validate({
            errorElement: 'span', //default input error message container
            errorClass: 'help-block help-block-error', // default input error message class
            focusInvalid: false, // do not focus the last invalid input
            ignore: "",  // validate all fields including form hidden input
            rules: {


                RoleID: {
                    required: true

                },

                ModuleID: {
                    required: true

                },

                ModuleLink: {
                    required: true

                }
            },

            messages: { // custom messages for radio buttons and checkboxes
                dllRole: {
                    required: "Role Required"
                },
                ModuleID: {
                    required: "Module Required"
                },
                ModuleLink: {
                    required: "ModuleLink Required"
                }

            },


            invalidHandler: function (event, validator) { //display error alert on form submit              
                success2.hide();
                error2.show();
                App.scrollTo(error2, -200);
            },

            errorPlacement: function (error, element) { // render error placement for each input type
                var icon = $(element).parent('.input-icon').children('i');
                icon.removeClass('fa-check').addClass("fa-warning");
                icon.attr("data-original-title", error.text()).tooltip({ 'container': 'body' });
            },

            highlight: function (element) { // hightlight error inputs
                $(element)
                    .closest('.form-group').removeClass("has-success").addClass('has-error'); // set error class to the control group   
            },

            unhighlight: function (element) { // revert the change done by hightlight

            },

            success: function (label, element) {
                var icon = $(element).parent('.input-icon').children('i');
                $(element).closest('.form-group').removeClass('has-error').addClass('has-success'); // set success class to the control group
                icon.removeClass("fa-warning").addClass("fa-check");


            },

            submitHandler: function (form) {
                success2.show();
                error2.hide();

                form[0].submit(); // submit the form



            }
        });


    }
    
    return {
        //main function to initiate the module
        init: function () {

          
            
            
            handleValidation3();
           
            EmployeeValidations();
            RoleValidation();
            CountryValidation();
            LPage();
        }

    };

}();

jQuery(document).ready(function () {
    FormValidation.init();
});