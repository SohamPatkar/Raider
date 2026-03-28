mergeInto(LibraryManager.library, {
    IsMobileDevice: function () {
        var ua = navigator.userAgent || navigator.vendor || window.opera;

        if (/android/i.test(ua)) return 1;
        if (/iPhone|iPad|iPod/i.test(ua)) return 1;

        return 0;
    }
});