$(document).ready(function () {
    $('#SubjectId').change(function () {
        $.ajax({
            type: "post",
            url: "/Factors/GetFactors",
            data: { subjectId: $('#SubjectId').val() },
            datatype: "json",
            traditional: true,
            success: function (data) {
                var district = "<select id='FactorId'>";
                for (var i = 0; i < data.length; i++) {
                    district = district + '<option value=' + data[i].Value + '>' + data[i].Text + '</option>';
                }
                district = district + '</select>';
                $('#FactorId').html(district);
            }
        });
    });

    $('#SubjectId').trigger('change');
});