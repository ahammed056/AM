

var PhoenixValidations = {
    Create: function() {

        var dtDate = new Date();
        var curr_year = dtDate.getFullYear();
        curr_year = curr_year + 40;

        // ** Add custom validator to validate DropDownlist ** //
        $.validator.addMethod("selectNone", function(value, element) {
            return this.optional(element) || element.selectedIndex != 0;
        });

        //custom validator to validate IP V4
        $.validator.addMethod("IP4Checker", function(value, element) {
            return this.optional(element) || /^(25[0-5]|2[0-4]\d|[01]?\d\d?)\.(25[0-5]|2[0-4]\d|[01]?\d\d?)\.(25[0-5]|2[0-4]\d|[01]?\d\d?)\.(25[0-5]|2[0-4]\d|[01]?\d\d?)$/i.test(value);
        });

        //custom validator to validate IP V6
        $.validator.addMethod("IP6Checker", function(value, element) {
            return this.optional(element) || /^((([0-9A-Fa-f]{1,4}:){7}[0-9A-Fa-f]{1,4})|(([0-9A-Fa-f]{1,4}:){6}:[0-9A-Fa-f]{1,4})|(([0-9A-Fa-f]{1,4}:){5}:([0-9A-Fa-f]{1,4}:)?[0-9A-Fa-f]{1,4})|(([0-9A-Fa-f]{1,4}:){4}:([0-9A-Fa-f]{1,4}:){0,2}[0-9A-Fa-f]{1,4})|(([0-9A-Fa-f]{1,4}:){3}:([0-9A-Fa-f]{1,4}:){0,3}[0-9A-Fa-f]{1,4})|(([0-9A-Fa-f]{1,4}:){2}:([0-9A-Fa-f]{1,4}:){0,4}[0-9A-Fa-f]{1,4})|(([0-9A-Fa-f]{1,4}:){6}((\b((25[0-5])|(1\d{2})|(2[0-4]\d)|(\d{1,2}))\b)\.){3}(\b((25[0-5])|(1\d{2})|(2[0-4]\d)|(\d{1,2}))\b))|(([0-9A-Fa-f]{1,4}:){0,5}:((\b((25[0-5])|(1\d{2})|(2[0-4]\d)|(\d{1,2}))\b)\.){3}(\b((25[0-5])|(1\d{2})|(2[0-4]\d)|(\d{1,2}))\b))|(::([0-9A-Fa-f]{1,4}:){0,5}((\b((25[0-5])|(1\d{2})|(2[0-4]\d)|(\d{1,2}))\b)\.){3}(\b((25[0-5])|(1\d{2})|(2[0-4]\d)|(\d{1,2}))\b))|([0-9A-Fa-f]{1,4}::([0-9A-Fa-f]{1,4}:){0,5}[0-9A-Fa-f]{1,4})|(::([0-9A-Fa-f]{1,4}:){0,6}[0-9A-Fa-f]{1,4})|(([0-9A-Fa-f]{1,4}:){1,7}:))$/i.test(value);
        });


        // ** Add Validation rules for controls of type "Free Text" ** //
        $("*[IsTextType]").each(function() {
            $(this).rules("add", { required: true, messages: { required: "<span  style='color:red'>*</span>"} });
        });

        // ** Add Validation rules for controls of type "IP Address" ** //
        $("*[IsIPType]").each(function() {
            //$(this).rules("add", { required: true, IP4Checker: true, messages: { required: "<span  style='color:red'>*</span>", IP4Checker: "<span  style='color:red'>* Invalid IP *</span>"} });
            //$(this).rules("add", { required: true, messages: { required: "<span  style='color:red'>*</span>"} });
            $(this).rules("add", { IP4Checker: true, messages: { IP4Checker: "<span  style='color:red'>* Invalid IP *</span>"} });
        });

        // ** Add Validation rules for controls of type "DropDownlist/Select" ** //
        $("*[IsSelectType]").each(function() {
            $(this).rules("add", { selectNone: true, messages: { selectNone: "<span  style='color:red'>*</span>"} });
        });

        // ** Add Validation rules for controls of type "Number/Numeric/OHRID" ** //
        $("*[IsNumberType]").each(function() {
            //$(this).rules("add", { required: true, number: true, messages: { required: "<span  style='color:red'>*</span>", number: "<span  style='color:red'>* Invalid number *</span>"} });
            $(this).rules("add", { number: true, messages: { number: "<span  style='color:red'>* Invalid number *</span>"} });
            //Restrict Textbox Entry [Allow Number/Numeric only]
            $(this).keydown(function(e) {
                var charCode = e.keyCode || e.which;
                if (charCode != 8 && charCode != 9 && charCode != 0 && charCode != 18 && (charCode < 48 || charCode > 57) && (charCode < 96 || charCode > 105)) {
                    return false;
                }
            });
        });

        // ** Add Validation rules for controls of type "Email" ** //
        $("*[IsEmailType]").each(function() {
            $(this).rules("add", {email: true, messages: { email: "<span  style='color:red'>* Invalid email ID *</span>"} });
        });

        // ** Add Validation rules for controls of type "Date" ** //
        $("*[IsDateType]").each(function() {
            //$(this).rules("add", { required: true, messages: { required: "<span  style='color:red'>*</span>"} });
            //Add datepicker
            $(this).datepicker({
                yearRange: '1960:' + curr_year,
                changeMonth: true,
                changeYear: true,
                gotoCurrent: true,
                showButtonPanel: false,
                onClose: function() {
                    $(this).focus();
                },
                showOn: 'button'
            }).next('button').css('height', '15px').text('').button({
                icons: { primary: 'ui-icon-calendar' },
                text: false
            });
            //Restrict Textbox Entry
            $(this).keydown(function(e) {
                var charCode = e.keyCode || e.which;
                if (charCode == 9)
                    return true;
                else
                    return false;
            });
            //Decrease the textbox width
            $(this).css("width", "120px");
        });

    }
};
