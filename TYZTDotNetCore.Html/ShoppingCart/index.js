$(document).ready(function () {
  const tblProducts = "products";
  getProducts();

  function getProducts() {
    const products = JSON.parse(localStorage.getItem(tblProducts)) || [];
    let productTable = $("#productTable").DataTable();
    productTable.clear();
    products.forEach((product) => {
      productTable.row
        .add([
          product.name,
          product.amount,
          product.price,
          `<button class="btn btn-success add-to-cart">Add to Cart</button>
                 <button class="btn btn-warning edit-product"><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil-square" viewBox="0 0 16 16">
                 <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
                 <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5z"/>
               </svg></button>
                 <button class="btn btn-danger delete-product"><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash-fill" viewBox="0 0 16 16">
                 <path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5M8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5m3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0"/>
               </svg></button>`,
        ])
        .draw();
    });
  }

  function createProduct(name, amount, price) {
    let products = JSON.parse(localStorage.getItem(tblProducts)) || [];
    const newProduct = {
      id: uuidv4(),
      name: name,
      amount: amount,
      price: price,
    };
    products.push(newProduct);
    localStorage.setItem(tblProducts, JSON.stringify(products));
    successNotifyMessage("Product successfully created!");
    getProducts();
  }

  function updateProduct(id, name, amount, price) {
    let products = JSON.parse(localStorage.getItem(tblProducts)) || [];
    const index = products.findIndex((product) => product.id === id);
    if (index !== -1) {
      products[index] = { id: id, name: name, amount: amount, price: price };
      localStorage.setItem(tblProducts, JSON.stringify(products));
      successNotifyMessage("Product successfully updated!");
      getProducts();
    } else {
      errorNotifyMessage("Product not found.");
    }
  }

  function deleteProduct(id) {
    let products = JSON.parse(localStorage.getItem(tblProducts)) || [];
    products = products.filter((product) => product.id !== id);
    localStorage.setItem(tblProducts, JSON.stringify(products));
    successNotifyMessage("Product successfully deleted!");
    getProducts();
  }

  function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, (c) =>
      (
        +c ^
        (crypto.getRandomValues(new Uint8Array(1))[0] & (15 >> (+c / 4)))
      ).toString(16)
    );
  }

  $("#addProductBtn").on("click", function () {
    Swal.fire({
      title: "Add New Product",
      html:
        '<input id="productName" class="swal2-input" placeholder="Product Name">' +
        '<input id="productAmount" class="swal2-input" placeholder="Product Amount">' +
        '<input id="productPrice" class="swal2-input" placeholder="Product Price">',
      showCancelButton: true,
      confirmButtonText: "Add",
      cancelButtonText: "Cancel",
      preConfirm: () => {
        const name = Swal.getPopup().querySelector("#productName").value;
        const amount = Swal.getPopup().querySelector("#productAmount").value;
        const price = Swal.getPopup().querySelector("#productPrice").value;
        if (!name || !price || !amount) {
          Notiflix.Notify.failure("Please enter product name and price");
          return false;
        }
        return { name: name, amount: amount, price: price };
      },
    }).then((result) => {
      if (result.isConfirmed) {
        createProduct(
          result.value.name,
          result.value.amount,
          result.value.price
        );
      }
    });
  });

  $("#productTable tbody").on("click", ".edit-product", function () {
    let productTable = $("#productTable").DataTable();
    let productRow = productTable.row($(this).closest("tr"));
    let productData = productRow.data();
    let productName = productData[0];
    let productAmount = productData[1];
    let productPrice = productData[2];

    Swal.fire({
      title: "Edit Product",
      html: `<input id="productName" class="swal2-input" value="${productName}" placeholder="Product Name">
            <input id="productAmount" class="swal2-input" value="${productAmount}" placeholder="Product Amount">
            <input id="productPrice" class="swal2-input" value="${productPrice}" placeholder="Product Price">`,
      showCancelButton: true,
      confirmButtonText: "Update",
      cancelButtonText: "Cancel",
      preConfirm: () => {
        const name = Swal.getPopup().querySelector("#productName").value;
        const amount = Swal.getPopup().querySelector("#productAmount").value;
        const price = Swal.getPopup().querySelector("#productPrice").value;
        if (!name || !price || !amount) {
          Notiflix.Notify.failure("Please enter product name and price");
          return false;
        }
        return { name: name, amount: amount, price: price };
      },
    }).then((result) => {
      if (result.isConfirmed) {
        let products = JSON.parse(localStorage.getItem(tblProducts)) || [];
        const product = products.find(
          (product) => product.name === productName
        );
        if (product) {
          updateProduct(
            product.id,
            result.value.name,
            result.value.amount,
            result.value.price
          );
        }
      }
    });
  });

  $("#productTable tbody").on("click", ".delete-product", function () {
    let productTable = $("#productTable").DataTable();
    let productRow = productTable.row($(this).closest("tr"));
    let productData = productRow.data();
    let productName = productData[0];

    Swal.fire({
      title: "Are you sure?",
      text: `Do you want to delete ${productName}?`,
      icon: "warning",
      showCancelButton: true,
      confirmButtonText: "Yes",
      cancelButtonText: "No",
    }).then((result) => {
      if (result.isConfirmed) {
        let products = JSON.parse(localStorage.getItem(tblProducts)) || [];
        const product = products.find(
          (product) => product.name === productName
        );
        if (product) {
          deleteProduct(product.id);
        }
      }
    });
  });

  $("#productTable tbody").on("click", ".add-to-cart", function () {
    let productTable = $("#productTable").DataTable();
    let productRow = productTable.row($(this).closest("tr"));
    let productData = productRow.data();
    let productName = productData[0];
    let productAmount = productData[1];
    let productPrice = productData[2];

    let cart = JSON.parse(localStorage.getItem("cart")) || [];
    cart.push({
      name: productName,
      amount: productAmount,
      price: productPrice,
    });
    localStorage.setItem("cart", JSON.stringify(cart));

    Swal.fire({
      title: "Added to Cart",
      text: `${productName} has been added to your cart!`,
      icon: "success",
      confirmButtonText: "OK",
    });
  });

  function successNotifyMessage(message) {
    Notiflix.Notify.success(message);
  }

  function errorNotifyMessage(message) {
    Notiflix.Notify.failure(message);
  }

  function successMessage(message) {
    Swal.fire({
      title: "Success!",
      text: message,
      icon: "success",
    });
  }

  function errorMessage(message) {
    Swal.fire({
      title: "Error!",
      text: message,
      icon: "error",
    });
  }
});
