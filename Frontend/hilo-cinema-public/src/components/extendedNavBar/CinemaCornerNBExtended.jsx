
const CinemaCornerNBExtended = () => {
    return (
        <div>
            <div className="absolute top-[65px] -left-[45px] hidden group-hover:md:block hover:md:block z-[800] drop-shadow-lg">
                <div className="bg-white min-w-[200px] text-center border border-white border-solid rounded">
                    <ul>
                        <li className="text-sm text-black hover:text-[#f26b38] hover:pl-0.5 hover:border-l-4 capitalize hover:border-[#fd841f] hover:bg-[#fb770b1a] transition-all duration-300">
                            <a className="block py-2" href="/dien-anh/">Thể loại phim</a>
                        </li>
                        <li className="text-sm text-black hover:text-[#f26b38] hover:pl-0.5 hover:border-l-4 capitalize hover:border-[#fd841f] hover:bg-[#fb770b1a] transition-all duration-300">
                            <a className="block py-2" href="/dien-vien/">Diễn Viên</a>
                        </li>
                        <li className="text-sm text-black hover:text-[#f26b38] hover:pl-0.5 hover:border-l-4 capitalize hover:border-[#fd841f] hover:bg-[#fb770b1a] transition-all duration-300">
                            <a className="block py-2" href="/dao-dien/">Đạo Diễn</a>
                        </li>
                        <li className="text-sm text-black hover:text-[#f26b38] hover:pl-0.5 hover:border-l-4 capitalize hover:border-[#fd841f] hover:bg-[#fb770b1a] transition-all duration-300">
                            <a className="block py-2" href="/binh-luan-phim/">Bình Luận Phim</a>
                        </li>
                        <li className="text-sm text-black hover:text-[#f26b38] hover:pl-0.5 hover:border-l-4 capitalize hover:border-[#fd841f] hover:bg-[#fb770b1a] transition-all duration-300">
                            <a className="block py-2" href="/movie-blog/">Blog Điện Ảnh</a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    );
};

export default CinemaCornerNBExtended;