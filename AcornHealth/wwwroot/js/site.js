 $(document).ready(function () {
            $("#sidebar").mCustomScrollbar({
                theme: "minimal"
            });

            $('#dismiss, .overlay').on('click', function () {
                $('#sidebar').removeClass('active');
                $('.overlay').removeClass('active');
            });

            $('#sidebarCollapse').on('click', function () {
                $('#sidebar').addClass('active');
                $('.overlay').addClass('active');
                $('.collapse.in').toggleClass('in');
                $('a[aria-expanded=true]').attr('aria-expanded', 'false');
            });
 });


new TypeIt("#description", {
	strings: "Visiting your doctor on a regular basis is key to a healthy life. Whether you're feeling the effects of the common cold or just coming in for a checkup, we want to make sure you have all...",
	speed: 50,
	waitUntilVisible: true,
}).go();