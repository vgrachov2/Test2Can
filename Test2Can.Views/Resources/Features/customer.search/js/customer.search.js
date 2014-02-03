$(function() {
		var customersOnPage = 10;
		$('.j-search-form_country').on('change', function () {
			var country = this.value;
			if (country && country.length > 0) {
				$.ajax({
					type: 'get',
					url: '/customers/'+country+'/cities',
					success: function (cities) {
							var citySelect = $('.j-search-form_city');
							citySelect.html('<option value=""> - </option>');
							$.map(cities, function (val, i) {
									citySelect.append('<option value' + val + '>' + val + '</option>');
							});
					}
				});
			}
		});

		$('.j_search_form').on('submit', function () {
			var form = getFormData($(this));
			form.Skip = 0;
			form.Take = customersOnPage;
			searchCustomer(form);

			return false;
		});

		$('body').on('click', '.j-search-form_paging', function () {
				var form = getFormData($('.j_search_form'));
				var page = $(this).data('page');
				form.Skip = (page - 1) * customersOnPage;
				form.Take = customersOnPage;
				searchCustomer(form);

				return false;
		});

	function searchCustomer(form) {
			$.ajax({
					type: 'get',
					url: '/customers',
					data: form,
					success: function (customers) {
							var table = $('.j-search-form_result > tbody');
						table.empty();
							$.map(customers.Customers, function (val, i) {
									var row = $('<tr></tr>');
									row.append('<td>' + val.CustomerId + '</td>');
									row.append('<td>' + val.CompanyName + '</td>');
									row.append('<td>' + val.ContractName + '</td>');
									row.append('<td>' + val.ContractTitle + '</td>');
									row.append('<td>' + val.Address + '</td>');
									row.append('<td>' + val.City + '</td>');
									row.append('<td>' + val.Region + '</td>');
									row.append('<td>' + val.PostalCode + '</td>');
									row.append('<td>' + val.Country + '</td>');
									row.append('<td>' + val.Phone + '</td>');
									row.append('<td>' + val.Fax + '</td>');
									table.append(row);
							});
							var paging = $('<div class="j-search-form_paging__container">');
							var pageCount = customers.Total / customersOnPage + 1;
							for (var i = 1; i < pageCount; i++) {
									paging.append('<a class="j-search-form_paging" href="#" data-page="' + i + '">' + i + ' </a>');
							}
							$('.j-search-form_paging__container').empty();
							$('.j-search-form_result').after(paging);
					}
			});
	}

		function getFormData($form) {
				var unindexed_array = $form.serializeArray();
				var indexed_array = {};

				$.map(unindexed_array, function (n, i) {
						indexed_array[n['name']] = n['value'];
				});

				return indexed_array;
		}
})