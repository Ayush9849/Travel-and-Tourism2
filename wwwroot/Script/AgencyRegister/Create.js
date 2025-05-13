function displaySelectedImage(elementId) {
    const selectedImage = document.getElementById(elementId);
    const fileInput = this.event.target;

    if (fileInput.files && fileInput.files[0]) {
        const reader = new FileReader();

        reader.onload = function (e) {
            selectedImage.src = e.target.result;
        };

        reader.readAsDataURL(fileInput.files[0]);
    }
};

function clicked() {
    console.log('1');
};

function displayPictures() {
    const fileNumber = document.getElementById('multipleImageUpload').dataset('image-count');
    const viewImageAfter = document.getElementById(`displayPicture[${fileNumber}]`);

    const fileInput = this.event.target;

    if (fileInput.files && fileInput.files[0]) {
        const reader = new FileReader();

        reader.onload = function (e) {
            viewImageAfter.src = e.target.result;
        };

        reader.readAsDataURL(fileInput.files[0]);
    }

    viewImageAfter.insertAdjacentHTML('afterend', `<img id="displayPicture[${parseInt(fileNumber) + 1}]" style="width: 200px; height: 200px; " class="rounded - circle mx - auto d - block img - thumbnail" alt="avatar1" src="~/images/default.png"/>`);
};

function addAddressSection() {
    const button = document.getElementById('addNewAddress');

    const addressAfter = document.getElementById(`addressList[${button.dataset.count}]`);
    addressAfter.insertAdjacentHTML('afterend', `<div class="col-md-12 row g-3" id="addressList[${parseInt(button.dataset.count) + 1}]"><div class= "col-6" ><label for="inputAddress" class="form-label">Address</label><input type="text" class="form-control" id="inputAddress" placeholder="1234 Main St"></div><div class="col-6"><label for="inputAddress2" class="form-label">Address 2</label><input type="text" class="form-control" id="inputAddress2" placeholder="Apartment, studio, or floor"></div><div class="col-md-6"><label for="inputCity" class="form-label">City</label><input type="text" class="form-control" id="inputCity"></div><div class="col-md-4"><label for="inputState" class="form-label">State</label><select id="inputState" class="form-select"><option selected>Choose...</option><option>...</option></select></div><div class="col-md-2"><label for="inputZip" class="form-label">Zip</label><input type="text" class="form-control" id="inputZip"></div></div >`);
    button.setAttribute('data-count', parseInt(button.dataset.count) + 1);
};
function removeLastAddressSection() {
    const button = document.getElementById('addNewAddress');

    const addressAfter = document.getElementById(`addressList[${button.dataset.count}]`);
    addressAfter.insertAdjacentHTML('afterend', `<div class="col-md-12 row g-3" id="addressList[${parseInt(button.dataset.count) + 1}]"><div class= "col-6" ><label for="inputAddress" class="form-label">Address</label><input type="text" class="form-control" id="inputAddress" placeholder="1234 Main St"></div><div class="col-6"><label for="inputAddress2" class="form-label">Address 2</label><input type="text" class="form-control" id="inputAddress2" placeholder="Apartment, studio, or floor"></div><div class="col-md-6"><label for="inputCity" class="form-label">City</label><input type="text" class="form-control" id="inputCity"></div><div class="col-md-4"><label for="inputState" class="form-label">State</label><select id="inputState" class="form-select"><option selected>Choose...</option><option>...</option></select></div><div class="col-md-2"><label for="inputZip" class="form-label">Zip</label><input type="text" class="form-control" id="inputZip"></div></div >`);
    button.setAttribute('data-count', parseInt(button.dataset.count) + 1);
};