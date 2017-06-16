$(document).ready(function () {
    if ($("#QualityAttributesMetricId").length > 0) {
        $('#CriteriaId')
            .change(function () {
                $.ajax({
                    type: "post",
                    url: "/QualityAttributesMetrics/GetQualityAttributesMetrics",
                    data: { criteriaId: $('#CriteriaId').val() },
                    datatype: "json",
                    traditional: true,
                    success: function (data) {
                        var district = "<select id='QualityAttributesMetricId'>";
                        for (var i = 0; i < data.length; i++) {
                            district = district + '<option value=' + data[i].Value + '>' + data[i].Text + '</option>';
                        }
                        district = district + '</select>';
                        $('#QualityAttributesMetricId').html(district);
                    }
                });
            });

    }
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

                        if ($("#QualityAttributesMetricId").length > 0) {
                            $('#CriteriaId').trigger('change');
                        }
                    }
                });
            });

    }
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


    $('#SubjectId').trigger('change');

});