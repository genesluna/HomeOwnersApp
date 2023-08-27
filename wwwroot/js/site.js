// Data Tables
$(document).ready(function () {
    $('#OwnersTable').DataTable({
        "responsive": true,
        "language": {
            "url": "/datatables/plug-ins/i18n/pt-BR.json"
        },
    });
});

// Bootstrap tooltips
var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))

var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
    return new bootstrap.Tooltip(tooltipTriggerEl)
})

// Bootstrap tabs
$(function () {
    const currentPage = location.pathname;
    $('.nav-tabs li a').each(function () {
        const $this = $(this);
        if (currentPage.toLowerCase().indexOf($this.attr('href').toLowerCase()) !== -1) {
            $this.addClass('active');
        }
    })
})