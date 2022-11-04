$(function () {
    let form = document.querySelector('form');
    form.addEventListener('submit', (e) => {
        e.preventDefault();
        return false;
    });
    $("button#btnApply").click(function () {
        registerResult();
    });
});

function registerResult() {
    var resultList = [];
    var subjectValue1 = parseInt($("#subject1").val());
    var gradeValue1 = $("#Grade1").val();
    const result1 = { Subject: { SubjectId: parseInt(subjectValue1) }, Grade: { GradeId: parseInt(gradeValue1)} };
    resultList.push(result1);

    var subjectValue2 = parseInt($("#subject2").val());
    var gradeValue2 = $("#Grade2").val();
    const result2 = { Subject: { SubjectId: parseInt(subjectValue2) }, Grade: { GradeId: parseInt(gradeValue2) } };
    resultList.push(result2);

    var subjectValue3 = parseInt($("#subject3").val());
    var gradeValue3 = $("#Grade3").val();
    const result3 = { Subject: { SubjectId: parseInt(subjectValue3) }, Grade: { GradeId: parseInt(gradeValue3) } };
    resultList.push(result3);

    var data = { ResultList: resultList };

    CreateResult(data).then((response) => {
        if (response) {
            toastr.success('Result Created Successfully');
            window.location = '/HomePage/Index';

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