$(document).ready(function () {
    $(document).on("click", ".show-more-btn", function () {
        let parent = $(".parentElem");

        let skipCount = $(parent).children().length;

        let productsCount = $("#parent-elem").attr("data-count");

        $.ajax({
            url: `course/ShowMoreOrLess?skip=${skipCount}`,
            type: "Get",
            success: function (res) {
                $(parent).append(res);
                skipCount = $(parent).children().length;
                if (skipCount >= productsCount) {
                    $(".show-more-btn").addClass("d-none")
                    $(".show-less-btn").removeClass("d-none")
                }
            }
        })
    })

    $(document).on("click", ".show-less-btn", function () {

        let parent = $(".parentElem");
        let skipCount = 0;

        $.ajax({
            url: `course/showmoreorless?skip=${skipCount}`,
            type: "Get",
            success: function (res) {
                $(parent).empty();
                $(parent).append(res);

                $(".show-less-btn").addClass("d-none")
                $(".show-more-btn").removeClass("d-none")
            }

        })
    })
})
