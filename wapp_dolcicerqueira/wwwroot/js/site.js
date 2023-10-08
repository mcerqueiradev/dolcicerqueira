// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


// File#: _1_parallax-image
// Usage: codyhouse.co/license
(function () {
    var ParallaxImg = function (element, rotationLevel) {
        this.element = element;
        this.figure = this.element.getElementsByClassName('js-parallax__wrapper')[0];
        this.imgs = this.element.getElementsByClassName('js-parallax__item');
        this.maxRotation = rotationLevel || 2; // rotate level
        this.scale = 1;
        this.animating = false;
        initParallax(this);
        initParallaxEvents(this);
    };

    function initParallax(element) {
        element.count = 0;
        window.requestAnimationFrame(checkImageLoaded.bind(element));
        // check if this is an image -> otherwise no need to check if loaded
        for (var i = 0; i < element.imgs.length; i++) {
            (function (i) {
                var loaded = false;
                if (element.imgs[i].tagName.toLowerCase() != 'img') {
                    element.count = element.count + 1;
                    return;
                }
                element.imgs[i].addEventListener('load', function () {
                    if (loaded) return;
                    element.count = element.count + 1;
                });
                if (element.imgs[i].complete && !loaded) {
                    loaded = true;
                    element.count = element.count + 1;
                }
            })(i);
        }

        // set translateZ
        for (var i = 0; i < element.imgs.length; i++) {
            if (element.imgs[i].getAttribute('data-parallax-distance')) {
                element.imgs[i].style.transform = 'translateZ(' + parseInt(element.imgs[i].getAttribute('data-parallax-distance')) + 'px' + ')';
            }
        }
    };

    function checkImageLoaded() {
        if (this.count >= this.imgs.length) {
            initScale(this);
            if (this.loaded) {
                window.cancelAnimationFrame(this.loaded);
                this.loaded = false;
            }
        } else {
            this.loaded = window.requestAnimationFrame(checkImageLoaded.bind(this));
        }
    };

    function initScale(element) {
        var maxImgResize = getMaxScale(element);
        element.scale = maxImgResize / (Math.sin(Math.PI / 2 - element.maxRotation * Math.PI / 180));
        element.figure.style.transform = 'scale(' + element.scale + ')';
        element.element.classList.add('parallax--loaded');
    };

    function getMaxScale(element) {
        var minWidth = 0;
        var maxWidth = 0;
        for (var i = 0; i < element.imgs.length; i++) {
            var width = element.imgs[i].getBoundingClientRect().width;
            if (width < minWidth || i == 0) minWidth = width;
            if (width > maxWidth || i == 0) maxWidth = width;
        }
        var scale = Math.ceil(10 * maxWidth / minWidth) / 10;
        if (scale < 1.1) scale = 1.1;
        return scale;
    }

    function initParallaxEvents(element) {
        element.element.addEventListener('mousemove', function (event) {
            if (element.animating) return;
            element.animating = true;
            window.requestAnimationFrame(moveImage.bind(element, event));
        });
    };

    function moveImage(event, timestamp) {
        var wrapperPosition = this.element.getBoundingClientRect();
        var rotateY = 2 * (this.maxRotation / wrapperPosition.width) * (wrapperPosition.left - event.clientX + wrapperPosition.width / 2);
        var rotateX = 2 * (this.maxRotation / wrapperPosition.height) * (event.clientY - wrapperPosition.top - wrapperPosition.height / 2);

        if (rotateY > this.maxRotation) rotateY = this.maxRotation;
        if (rotateY < -1 * this.maxRotation) rotateY = -this.maxRotation;
        if (rotateX > this.maxRotation) rotateX = this.maxRotation;
        if (rotateX < -1 * this.maxRotation) rotateX = -this.maxRotation;
        this.figure.style.transform = 'scale(' + this.scale + ') rotateX(' + rotateX + 'deg) rotateY(' + rotateY + 'deg)';
        this.animating = false;
    };

    window.ParallaxImg = ParallaxImg;

    //initialize the ParallaxImg objects
    var parallaxImgs = document.getElementsByClassName('js-parallax');
    if (parallaxImgs.length > 0) {
        for (var i = 0; i < parallaxImgs.length; i++) {
            (function (i) {
                var rotationLevel = parallaxImgs[i].getAttribute('data-perspective');
                new ParallaxImg(parallaxImgs[i], rotationLevel);
            })(i);
        }
    };
}());