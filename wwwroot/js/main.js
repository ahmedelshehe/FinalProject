    const checkboxes = document.querySelectorAll('input[type="checkbox"]');

    const checkAllButton = document.querySelector('button[type="button"][onclick="checkAllCheckboxes()"]');

    function checkAllCheckboxes() {
        for (const checkbox of checkboxes) {
            checkbox.checked = true;
        }

        checkAllButton.disabled = true;
        document.querySelector('button[type="button"][onclick="uncheckAllCheckboxes()"]').disabled = false;
    }

    function uncheckAllCheckboxes() {
        for (const checkbox of checkboxes) {
            checkbox.checked = false;
        }

        checkAllButton.disabled = false;
        document.querySelector('button[type="button"][onclick="uncheckAllCheckboxes()"]').disabled = true;
    }

    for (const checkbox of checkboxes) {
        checkbox.addEventListener('change', function () {
            // Check if any checkboxes are unchecked.
            for (const checkbox of checkboxes) {
                if (!checkbox.checked) {
                    // Enable the "Check All" button and disable the "Uncheck All" button.
                    checkAllButton.disabled = false;
                    document.querySelector('button[type="button"][onclick="uncheckAllCheckboxes()"]').disabled = true;
                    return;
                }
            }

            checkAllButton.disabled = true;
            document.querySelector('button[type="button"][onclick="uncheckAllCheckboxes()"]').disabled = false;
        });
    }
