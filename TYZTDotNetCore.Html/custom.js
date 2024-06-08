function uuidv4() {
  return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, (c) =>
    (
      +c ^
      (crypto.getRandomValues(new Uint8Array(1))[0] & (15 >> (+c / 4)))
    ).toString(16)
  );
}

function successMessage(message) {
  // Swal.fire({
  //   title: "Success!",
  //   text: message,
  //   icon: "success",
  // });

  Notiflix.Report.success("Success", message, "Okay");
}

function errorMessage(message) {
  // Swal.fire({
  //   title: "Error!",
  //   text: message,
  //   icon: "error",
  // });
  Notiflix.Report.failure("Error", message, "Okay");
}

function successNotifyMessage(message) {
  Notiflix.Notify.success(message);
}

function confirmMessage(message) {
  let confirmMessageResult = new Promise(function (success, error) {
    //   Swal.fire({
    //     title: "Confirm",
    //     text: message,
    //     icon: "warning",
    //     showCancelButton: true,
    //     confirmButtonText: "Yes",
    //   }).then((result) => {
    //     if (result.isConfirmed) {
    //       success();
    //     } else {
    //       error();
    //     }
    //   });
    Notiflix.Confirm.show(
      "Notiflix Confirm",
      message,
      "Yes",
      "No",
      function okCb() {
        success();
      },
      function cancelCb() {
        error();
      }
    );
  });
  return confirmMessageResult;
}
