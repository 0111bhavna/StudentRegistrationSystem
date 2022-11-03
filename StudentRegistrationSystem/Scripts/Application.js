﻿$(function () {
    let form = document.querySelector('form');
    form.addEventListener('submit', (e) => {
        e.preventDefault();
        return false;
    });
    $("#btnApply").click(function () {
        registerResult();
    });
});

function registerResult() {
    var resultList = [];

    var subjectValue1 = parseInt($("#subject1").val());
    var gradeValue1 = $("#Grade1").val();
    const result1 = { SubjectId: subjectValue1, SubjectGrade: gradeValue1 };
    resultList.push(result1);

    var subjectValue2 = parseInt($("#subject2").val());
    var gradeValue2 = $("#Grade2").val();
    const result2 = { SubjectId: subjectValue2, SubjectGrade: gradeValue2 };
    resultList.push(result2);

    var subjectValue3 = parseInt($("#subject3").val());
    var gradeValue3 = $("#Grade3").val();
    const result3 = { SubjectId: subjectValue3, SubjectGrade: gradeValue3 };
    resultList.push(result3);

    var data = { Results: resultList };

    CreateResult(data).then((response) => {
        if (response.result) {
            toastr.success('Result Created Successfully');
            window.location = response.url;

        }
        else {
            toastr.error('Unable to create result');
            return false;
        }
    }).catch((error) => {
        toastr.error('Unable to create result!');
        console.error(error);
    });
};

function CreateResult(resultList) {
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "POST",
            url: "/Application/AddStudentResult",
            data: JSON.stringify(resultList),
            dataType: 'json',
            contentType: 'application/json',
            success: function (data) {
                resolve(data)
            },
            error: function (error) {
                reject(error)
            }
        })
    });
}