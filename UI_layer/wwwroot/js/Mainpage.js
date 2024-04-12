$(document).ready(function () {
    // Check if the success message exists
    if ($('.alert-success').length > 0) {
        // Auto-dismiss the success message after 3 seconds
        setTimeout(function () {
            $('.alert-success').fadeOut('slow', function () {
                $(this).remove(); // Remove the element after fading out
            });
        }, 3000);
    }
});
