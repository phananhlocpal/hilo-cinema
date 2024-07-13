import MovieCardItem from "../common_components/comom_item/MovieCardItem";
import TitleItem from "../common_components/comom_item/TitleItem";

const MovieNBExtended = () => {
    return (
        <div className="absolute top-[65px] -left-[45px] hidden group-hover:md:block hover:md:block z-[800] transition-all duration-300 ease-in-out drop-shadow-lg">
                <div className="bg-white min-w-[250px] border border-white border-solid rounded px-6 py-4">
                    <div className="movie__show">
                        <TitleItem title="PHIM ĐANG CHIẾU"/>
                        <ul className="flex flex-row gap-7 justify-between">
                            <MovieCardItem title="Kẻ Trộm Mặt Trăng 4" imageUrl="https://cdn.galaxycine.vn/media/2024/5/6/inside-out-2-3_1714970461256.jpg" />
                            <MovieCardItem title="Kẻ Trộm Mặt Trăng 4" imageUrl="https://cdn.galaxycine.vn/media/2024/5/6/inside-out-2-3_1714970461256.jpg" />
                            <MovieCardItem title="Kẻ Trộm Mặt Trăng 4" imageUrl="https://cdn.galaxycine.vn/media/2024/5/6/inside-out-2-3_1714970461256.jpg" />

                        </ul>
                    </div>
                </div>
            </div>
    );
};

export default MovieNBExtended;