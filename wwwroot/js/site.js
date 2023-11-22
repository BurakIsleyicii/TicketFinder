(function ($) {
    $(document).ready(function () {
        $('#busLocationsListForOrigin, #busLocationsListForDestination').select2({
            ajax: {
                url: '/Home/GetBusLocations',
                dataType: 'json',
                data: function (params) {
                    return {
                        q: params.term,
                    };
                },
                processResults: function (data) {
                    return {
                        results: data.data.map(function (item) {
                            return {
                                id: item.id,
                                text: item.name,
                            };
                        }),
                    };
                },
            },
        });

        $('#busLocationsListForOrigin').on('change', function () {
            var oldVal = $("#originId").val();
            var oldText = $("#originName").val();
            var selectedOption = $(this).find('option:selected');

            var destination = $('#busLocationsListForDestination').find('option:selected');
            var destinationValue = destination.val();
            var destinationText = destination.text();

            if (selectedOption.val() === destinationValue) {
                $(this).val(destinationValue).trigger('change.select2');
                $('#busLocationsListForDestination').val(oldVal).trigger('change.select2');
                $('#destinationName').val(oldText);
                $('#originName').val(destinationText);
            } else {
                $('#originName').val(selectedOption.text());
            }
        });

        $('#busLocationsListForDestination').on('change', function () {
            var oldVal = $("#destinationId").val();
            var oldText = $("#destinationName").val();
            var selectedOption = $(this).find('option:selected');

            var origin = $('#busLocationsListForOrigin').find('option:selected');
            var originValue = origin.val();
            var originText = origin.text();

            if (selectedOption.val() === originValue) {
                $(this).val(originValue).trigger('change.select2');
                $('#busLocationsListForOrigin').val(oldVal).trigger('change.select2');
                $('#originName').val(oldText);
                $('#destinationName').val(originText);
            } else {
                $('#destinationName').val(selectedOption.text());
            }
        });

        $('#searchForm').submit(function (e) {
            e.preventDefault();
            var formData = $(this).serializeArray();
            var customUrl = 'seferler/' + formData.map(item => item.value).join('/');
            window.location.href = customUrl;
        });
    });

    function swapLocations() {
        var originValue = $("#busLocationsListForOrigin").val();
        var destinationValue = $("#busLocationsListForDestination").val();
        $("#busLocationsListForOrigin").val(destinationValue).trigger("change");
        $("#busLocationsListForDestination").val(originValue).trigger("change");
    }
    window.swapLocations = swapLocations;

    function selectToday() {
        $("#departureDate").val(new Date().toISOString().split('T')[0]);
    }
    window.selectToday = selectToday;

    function selectTomorrow() {
        var tomorrow = new Date();
        tomorrow.setDate(tomorrow.getDate() + 1);
        $("#departureDate").val(tomorrow.toISOString().split('T')[0]);
    }
    window.selectTomorrow = selectTomorrow;

})(jQuery);