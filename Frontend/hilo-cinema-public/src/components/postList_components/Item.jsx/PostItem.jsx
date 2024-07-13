import { ThumbUpAlt, Visibility } from '@mui/icons-material';

const PostItem = ({ movie }) => {
    return (
        <li className="mb-2">
            <section className="post__item flex justify-start gap-2 md:gap-4">
                <a className="md:w-[255px] w-auto" href="/phim/avengers-endgame/">
                    <img alt={movie.title} loading="lazy" width="255" height="170" decoding="async" data-nimg="1" className="rounded w-[109px] h-[79px] md:w-[255px] md:h-[170px] object-cover duration-500 ease-in-out group-hover:opacity-100 scale-100 blur-0 grayscale-0)" src="https://www.galaxycine.vn/media/2019/4/10/640wx396h_1554864314405.jpg" style={{ color: 'transparent' }}
                    />
                </a>
                <div className="flex-1">
                    <a className="text-black-10 text-sm md:text-[#333] md:text-lg font-semibold md:font-semibold not-italic transition-all duration-500 ease-in-out item__title" href="/phim/avengers-endgame/">
                        {movie.title}
                    </a>
                    <div className="post__description">
                        <button type="button" className="text-white mr-2 bg-blue-500 hover:bg-blue-800 focus:ring-1 focus:ring-blue-300 rounded text-xs py-1 px-2 md:px-3 text-[10px] md:text-[12px]">
                            <ThumbUpAlt className="mr-1" style={{ fontSize: '12px' }} /> Thích
                        </button>
                        <button className="text-xs bg-gray-300 rounded mr-2 py-1 px-2 md:px-3 text-[10px] md:text-[12px]">
                            <Visibility className="mr-1" style={{ fontSize: '12px' }} /> 2601938
                        </button>
                        <div className="wysiwyg text-grey-80 text-sm font-normal not-italic leading-6 mt-2 hidden md:block content__data">
                            <p>
                                <span style={{ fontFamily: 'Arial,Helvetica,sans-serif' }}>
                                    <span style={{ fontSize: '14px' }}>
                                        {movie.description}{" "}
                                        <a href="https://www.galaxycine.vn/dat-ve/avengers-endgame">
                                            <strong>{movie.title}</strong>
                                        </a>
                                        ?{" "}
                                    </span>
                                </span>
                            </p>
                        </div>
                    </div>
                </div>
            </section>
        </li>
    );
};


export default PostItem;
