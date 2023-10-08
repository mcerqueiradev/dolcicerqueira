module.exports = {
    content: [
        './Pages/**/*.cshtml',
        './Views/**/*.cshtml'
    ],
    theme: {
        extend: {
            fontFamily: {
                'poppins': ['Poppins', 'sans-serif'],
                'rubik': ['Rubik', 'sans-serif']
            },
            backgroundImage: {             
                'cake': "url('/assets/cake.png')",
                'cake2': "url('https://images.unsplash.com/photo-1622896784083-cc051313dbab?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1974&q=80')",
                'cake3': "url('https://images.pexels.com/photos/1748863/pexels-photo-1748863.jpeg')",
            }
        },
        animationDuration: {
            2000: '20s',
            'long': '10s',
            'very-long': '20s',
        },
        colors: {
            'blue': '#5368A6',
            'lightblue': '#C4D0F2',
            'pink': '#D93B92',
            'lightpink': '#F2BDEF',
            'white': '#FFFFFF',
            'lime': '#EDF263',
            'card': '#F7F7F7',
            'gray': '#475569',
            'black': '#000000',
        },

    },
    plugins: [
        require('tailwind-scrollbar')({ nocompatible: true }),
        require('flowbite-typography'),
    ],
}