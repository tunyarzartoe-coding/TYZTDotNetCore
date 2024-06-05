$(document).ready(function() {
    let productTable = $('#productTable').DataTable();

    function loadProducts() {
        let products = JSON.parse(localStorage.getItem('products')) || [];
        productTable.clear();
        products.forEach(product => {
            productTable.row.add([
                product.name,
                product.price,
                `<button class="btn btn-success add-to-cart">Add to Cart</button>
                 <button class="btn btn-warning edit-product">Edit</button>
                 <button class="btn btn-danger delete-product">Delete</button>`
            ]).draw();
        });
    }

    function saveProducts(products) {
        localStorage.setItem('products', JSON.stringify(products));
    }

    $('#addProductBtn').on('click', function() {
        Swal.fire({
            title: 'Add New Product',
            html: '<input id="productName" class="swal2-input" placeholder="Product Name">' +
                  '<input id="productPrice" class="swal2-input" placeholder="Product Price">',
            showCancelButton: true,
            confirmButtonText: 'Add',
            cancelButtonText: 'Cancel',
            preConfirm: () => {
                const name = Swal.getPopup().querySelector('#productName').value;
                const price = Swal.getPopup().querySelector('#productPrice').value;
                if (!name || !price) {
                    Swal.showValidationMessage(`Please enter product name and price`);
                }
                return { name: name, price: price };
            }
        }).then((result) => {
            if (result.isConfirmed) {
                let products = JSON.parse(localStorage.getItem('products')) || [];
                products.push(result.value);
                saveProducts(products);
                loadProducts();
                Swal.fire('Added!', 'Product has been added.', 'success');
            }
        });
    });

    $('#productTable tbody').on('click', '.edit-product', function() {
        let productRow = productTable.row($(this).closest('tr'));
        let productData = productRow.data();
        let productName = productData[0];
        let productPrice = productData[1];

        Swal.fire({
            title: 'Edit Product',
            html: `<input id="productName" class="swal2-input" value="${productName}" placeholder="Product Name">
                   <input id="productPrice" class="swal2-input" value="${productPrice}" placeholder="Product Price">`,
            showCancelButton: true,
            confirmButtonText: 'Update',
            cancelButtonText: 'Cancel',
            preConfirm: () => {
                const name = Swal.getPopup().querySelector('#productName').value;
                const price = Swal.getPopup().querySelector('#productPrice').value;
                if (!name || !price) {
                    Swal.showValidationMessage(`Please enter product name and price`);
                }
                return { name: name, price: price };
            }
        }).then((result) => {
            if (result.isConfirmed) {
                let products = JSON.parse(localStorage.getItem('products')) || [];
                products = products.map(product => product.name === productName ? result.value : product);
                saveProducts(products);
                loadProducts();
                Swal.fire('Updated!', 'Product has been updated.', 'success');
            }
        });
    });

    $('#productTable tbody').on('click', '.delete-product', function() {
        let productRow = productTable.row($(this).closest('tr'));
        let productData = productRow.data();
        let productName = productData[0];

        Swal.fire({
            title: 'Are you sure?',
            text: `Do you want to delete ${productName}?`,
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Yes',
            cancelButtonText: 'No'
        }).then((result) => {
            if (result.isConfirmed) {
                let products = JSON.parse(localStorage.getItem('products')) || [];
                products = products.filter(product => product.name !== productName);
                saveProducts(products);
                loadProducts();
                Swal.fire('Deleted!', `${productName} has been deleted.`, 'success');
            }
        });
    });

    $('#productTable tbody').on('click', '.add-to-cart', function() {
        let productRow = productTable.row($(this).closest('tr'));
        let productData = productRow.data();
        let productName = productData[0];
        let productPrice = productData[1];

        let cart = JSON.parse(localStorage.getItem('cart')) || [];
        cart.push({ name: productName, price: productPrice });
        localStorage.setItem('cart', JSON.stringify(cart));

        Swal.fire({
            title: 'Added to Cart',
            text: `${productName} has been added to your cart!`,
            icon: 'success',
            confirmButtonText: 'OK'
        });
    });

    loadProducts();
});
