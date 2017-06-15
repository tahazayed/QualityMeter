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
                if ($("#CriteriaId").length > 0) {
                    $('#FactorId').trigger('change');
                }
            }
        });
    });
    if ($("#CriteriaId").length > 0) {
        $('#FactorId')
            .change(function () {
                $.ajax({
                    type: "post",
                    url: "/Criterias/GetCriterias",
                    data: { factorId: $('#FactorId').val() },
                    datatype: "json",
                    traditional: true,
                    success: function (data) {
                        var district = "<select id='CriteriaId'>";
                        for (var i = 0; i < data.length; i++) {
                            district = district + '<option value=' + data[i].Value + '>' + data[i].Text + '</option>';
                        }
                        district = district + '</select>';
                        $('#CriteriaId').html(district);
                    }
                });
            });

    }
    $('#SubjectId').trigger('change');
    if ($("#CriteriaId").length > 0) {
        $('#FactorId').trigger('change');
    }
});