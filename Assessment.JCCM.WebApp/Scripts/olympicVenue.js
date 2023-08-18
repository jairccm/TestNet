$(function () {

    $(".deleteItem").on("click", async (event) => {
        event.preventDefault();

        Swal.fire({
            title: 'Esta seguro?',
            text: "No se podrá revertir esto",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then(async (result) => {
            if (result.isConfirmed) {
                const response = await fetch(urlDelete, config);
                if (response.ok) {
                    const data = await response.json();
                    if (data.isSuccess) {
                       await  Swal.fire({
                            icon: 'success',
                            title: '',
                            text: data.Message
                        });

                        location.reload();
                    } else {
                        Swal.fire({
                            icon: 'error',
                            title: '',
                            text: data.Message
                        });
                    }
                } else {
                    Swal.fire({
                        icon: 'error',
                        title: '',
                        text: 'A ocurrido un error!'
                    });
                }
            }
        })

        const urlDelete = event.currentTarget.href;
        const config = {
            method: "POST", // *GET, POST, PUT, DELETE, etc.
            headers: {
                "Content-Type": "application/json",
            }
        }

        
    });

    $("#form").on("submit", async (event) => {
        event.preventDefault();

        const config = {
            method: "POST", // *GET, POST, PUT, DELETE, etc.
            headers: {
                //"Content-Type": "application/json",
                'Content-Type': 'application/x-www-form-urlencoded'
            },
            body: $("#form").serialize() // body data type must match "Content-Type" header
        }

        const response = await fetch(urlCreate, config);

        if (response.ok) {
            const data = await response.json();
            if (data.isSuccess) {
                await Swal.fire({
                    icon: 'success',
                    title: '',
                    text: data.Message
                });

                location.href = urlList;
            } else {
                Swal.fire({
                    icon: 'error',
                    title: '',
                    text: data.Message
                });
            }
        } else {
            Swal.fire({
                icon: 'error',
                title: '',
                text: 'A ocurrido un error!'
            });
        }

    });

    $("#formUpdate").on("submit", async (event) => {
        event.preventDefault();

        const config = {
            method: "POST", // *GET, POST, PUT, DELETE, etc.
            headers: {
                //"Content-Type": "application/json",
                'Content-Type': 'application/x-www-form-urlencoded'
            },
            body: $("#formUpdate").serialize() // body data type must match "Content-Type" header
        }

        const response = await fetch(urlEdit, config);

        if (response.ok) {
            const data = await response.json();
            if (data.isSuccess) {
                await Swal.fire({
                    icon: 'success',
                    title: '',
                    text: data.Message
                });

                location.href = urlList;
            } else {
                Swal.fire({
                    icon: 'error',
                    title: '',
                    text: data.Message
                });
            }
        } else {
            Swal.fire({
                icon: 'error',
                title: '',
                text: 'A ocurrido un error!'
            });
        }

    });

});