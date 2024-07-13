const initialState = {
    carouselImages: [
        { src: 'https://cdn.galaxycine.vn/media/2024/5/27/2048_1716778970480.jpg' },
        { src: 'https://cdn.galaxycine.vn/media/2024/6/13/tw-2048_1718252049014.jpg' },
        { src: 'https://cdn.galaxycine.vn/media/2024/6/6/xummer-combo-2048x682_1717668878472.jpg' },
    ],
    blogs: [
        {
            id: 1,
            title: '[Review] Cửu Long Thành Trại Vây Thành: Hồi Sinh Thời Huy Hoàng Của Điện Ảnh Hong Kong',
            imageUrl: 'https://www.galaxycine.vn/media/2024/6/19/750_1718788973451.jpg',
            likes: 68,
            views: 223,
            href: '/binh-luan-phim/review-cuu-long-thanh-trai-vay-thanh-hoi-sinh-thoi-huy-hoang-cua-dien-anh-hongkong/'
        },
        {
            id: 1,
            title: '[Review] Cửu Long Thành Trại Vây Thành: Hồi Sinh Thời Huy Hoàng Của Điện Ảnh Hong Kong',
            imageUrl: 'https://www.galaxycine.vn/media/2024/6/19/750_1718788973451.jpg',
            likes: 68,
            views: 223,
            href: '/binh-luan-phim/review-cuu-long-thanh-trai-vay-thanh-hoi-sinh-thoi-huy-hoang-cua-dien-anh-hongkong/'
        },
        {
            id: 1,
            title: '[Review] Cửu Long Thành Trại Vây Thành: Hồi Sinh Thời Huy Hoàng Của Điện Ảnh Hong Kong',
            imageUrl: 'https://www.galaxycine.vn/media/2024/6/19/750_1718788973451.jpg',
            likes: 68,
            views: 223,
            href: '/binh-luan-phim/review-cuu-long-thanh-trai-vay-thanh-hoi-sinh-thoi-huy-hoang-cua-dien-anh-hongkong/'
        },
        {
            id: 1,
            title: '[Review] Cửu Long Thành Trại Vây Thành: Hồi Sinh Thời Huy Hoàng Của Điện Ảnh Hong Kong',
            imageUrl: 'https://www.galaxycine.vn/media/2024/6/19/750_1718788973451.jpg',
            likes: 68,
            views: 223,
            href: '/binh-luan-phim/review-cuu-long-thanh-trai-vay-thanh-hoi-sinh-thoi-huy-hoang-cua-dien-anh-hongkong/'
        },
    ],
    promotionalNew: [
        {
            id: 1,
            title: "Cine Với Cạ Cứng - Tụ Tập Vui Quá Trời",
            url: "https://cdn.galaxycine.vn/media/2024/5/24/750_1716521545766.jpg",
        },
        {
            id: 2,
            title: "Cine Với Cạ Cứng - Tụ Tập Vui Quá ",
            url: "https://cdn.galaxycine.vn/media/2024/4/2/750_1712051414517.jpg",
        },
        {
            id: 3,
            title: "Cine Với Cạ Cứng - Tụ Tập Vui",
            url: "https://cdn.galaxycine.vn/media/2024/4/15/galaxy-da-co-1800x1200_1713168778020.jpg",
        },
        {
            id: 4,
            title: "Cine Với Cạ Cứng - Tụ Tập ",
            url: "https://cdn.galaxycine.vn/media/2023/5/23/quy-dinh-do-tuoi-digital-1350x900_1684835377244.jpg",
        },
        {
            id: 5,
            title: "Cine Với Cạ Cứng - Tụ Tập Vui Quá  Trời Trời Trời Trời Trời Trời Trời Trời Trời",
            url: "https://cdn.galaxycine.vn/media/2024/3/21/galaxy-studio-va-samsung-k-ket-hop-tac-chien-luoc--tai-dinh-nghia-su-ket-hop-giua-dien-anh--cong-nghe-6_1711006015662.jpg",
        },
    ],
    tabValue: 0,
    recentMovieList: [
        { id: 1, title: 'Những mảnh ghép cảm xúc 2', img: 'https://cdn.galaxycine.vn/media/2024/5/6/inside-out-2-3_1714970461256.jpg'},
        { id: 2, title: 'Thầy trừ tà', img: 'https://cdn.galaxycine.vn/media/2024/6/5/exorcim-500_1717573379987.jpg'},
        { id: 3, title: 'Cửu Long Thành Trại: Vây Thành', img: 'https://cdn.galaxycine.vn/media/2024/6/3/cuu-long-thanh-trai-vay-thanh-1_1717402596500.jpg' },
        { id: 4, title: 'Những Gã Trai Hư: Chơi Hay Bị Xơi', img: 'https://cdn.galaxycine.vn/media/2024/6/5/bad-boy-500_1717559748357.jpg' },
        { id: 5, title: 'Những mảnh ghép cảm xúc 2', img: 'https://cdn.galaxycine.vn/media/2024/5/6/inside-out-2-3_1714970461256.jpg'},
        { id: 6, title: 'Thầy trừ tà', img: 'https://cdn.galaxycine.vn/media/2024/6/5/exorcim-500_1717573379987.jpg'},
        { id: 7, title: 'Cửu Long Thành Trại: Vây Thành', img: 'https://cdn.galaxycine.vn/media/2024/6/3/cuu-long-thanh-trai-vay-thanh-1_1717402596500.jpg' },
        { id: 8, title: 'Những Gã Trai Hư: Chơi Hay Bị Xơi', img: 'https://cdn.galaxycine.vn/media/2024/6/5/bad-boy-500_1717559748357.jpg' }
    ],
    upcommingMovieList : [
        { id: 1, title: 'Những Gã Trai Hư: Chơi Hay Bị Xơi', img: 'https://cdn.galaxycine.vn/media/2024/6/5/bad-boy-500_1717559748357.jpg' },
        { id: 2, title: 'Cửu Long Thành Trại: Vây Thành', img: 'https://cdn.galaxycine.vn/media/2024/6/3/cuu-long-thanh-trai-vay-thanh-1_1717402596500.jpg' },
        { id: 3, title: 'Thầy trừ tà', img: 'https://cdn.galaxycine.vn/media/2024/6/5/exorcim-500_1717573379987.jpg'},
        { id: 4, title: 'Những mảnh ghép cảm xúc 2', img: 'https://cdn.galaxycine.vn/media/2024/5/6/inside-out-2-3_1714970461256.jpg'},
        { id: 5, title: 'Những Gã Trai Hư: Chơi Hay Bị Xơi', img: 'https://cdn.galaxycine.vn/media/2024/6/5/bad-boy-500_1717559748357.jpg' },
        { id: 6, title: 'Cửu Long Thành Trại: Vây Thành', img: 'https://cdn.galaxycine.vn/media/2024/6/3/cuu-long-thanh-trai-vay-thanh-1_1717402596500.jpg' },
        { id: 7, title: 'Thầy trừ tà', img: 'https://cdn.galaxycine.vn/media/2024/6/5/exorcim-500_1717573379987.jpg'},
        { id: 8, title: 'Những mảnh ghép cảm xúc 2', img: 'https://cdn.galaxycine.vn/media/2024/5/6/inside-out-2-3_1714970461256.jpg'},
       
    ],
}

const homeReducer = (state = initialState, action) => {
    switch (action.type) {
        case "SET_CAROUSEL_IMAGES":
            return {
                ...state,
                carouselImages: action.payload,
            };
        case "SET_BLOGS":
            return {
                ...state,
                blogs: action.payload,
            };
        case "SET_PROMOTION_NEWS":
            return {
                ...state,
                blogs: action.payload,
            };
        case "SET_TAB":
            return {
                ...state,
                tabValue: action.payload,
            };
        default:
            return state;
    }
}

export default homeReducer;