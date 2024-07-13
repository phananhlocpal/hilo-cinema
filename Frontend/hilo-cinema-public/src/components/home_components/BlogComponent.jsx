import { ExpandMore, ThumbUp, Visibility } from "@mui/icons-material";
import { useSelector } from "react-redux";

const BlogComponent = () => {
    const blogs = useSelector((state) => state.home.blogs);

    return (
        <div>
            <div className="my-0 mx-auto pb-8 screen1390:max-w-screen-xl xl:max-w-screen-screen1200 lg:max-w-4xl md:max-w-4xl md:px-4 sm:px-[45px] px-[16px]">
                <div className="md:text-center transition-all duration-300">
                    <div className="mt-8">
                        <article className="grid md:grid-cols-2 md:gap-x-6 gap-4">
                            {
                                <a className="flex flex-col gap-y-4">
                                    <aside className="max-h-[476px] group transition-all duration-300 ease-in-out md:hover:text-blue-10">
                                        <a href="/binh-luan-phim/review-cuu-long-thanh-trai-vay-thanh-hoi-sinh-thoi-huy-hoang-cua-dien-anh-hongkong/">
                                            <img alt="[Review] Cửu Long Thành Trại Vây Thành: Hồi Sinh Thời Huy Hoàng Của Điện Ảnh Hong Kong" loading="lazy" width="445" height="300" decoding="async" data-nimg="1" className="rounded-lg md:rounded md:w-full w-full h-[232px] md:h-[215px] lg:h-[300px] xl:h-full max-h-[400px] group-hover:md:scale-105 transition-all object-cover duration-500 ease-in-out group-hover:opacity-100 scale-100 blur-0 grayscale-0)" src="https://www.galaxycine.vn/media/2024/6/19/750_1718788973451.jpg" />
                                        </a>
                                        <aside className="descriptions text-left mt-4 md:mt-7">
                                            <a className="text-xl font-bold md:hover:text-blue-10 transition-all duration-300 overflow-hidden" href="/binh-luan-phim/review-cuu-long-thanh-trai-vay-thanh-hoi-sinh-thoi-huy-hoang-cua-dien-anh-hongkong/">[Review] Cửu Long Thành Trại Vây Thành: Hồi Sinh Thời Huy Hoàng Của Điện Ảnh Hong Kong</a>
                                            <div className="card__votes flex mt-2">
                                                <button type="button" className="h-[20px] text-xs text-white hover:text-white mr-2 bg-blue-40 hover:bg-blue-800 focus:ring-1 focus:ring-blue-300 rounded px-3">
                                                    <ThumbUp />
                                                    Thích
                                                </button>
                                                <button className="text-xs text-black-10 bg-grey-30 h-[20px] rounded mr-2 px-3 hover:text-black-10">
                                                    <Visibility />
                                                    68
                                                </button>
                                            </div>
                                        </aside>
                                    </aside>
                                </a>
                            }

                            <article className="flex flex-col gap-y-4">
                                {blogs.slice(1, 4).map((blog, index) => (
                                    <aside key={index} className="flex gap-x-2 w-full max-h-[80px] md:max-h-[150px] group transition-all duration-300 ease-in-out md:hover:text-blue-10">
                                        <a className="w-[30%] md:w-[35%]" href={blog.href}>
                                            <img alt={blog.title} loading="lazy" width="195" height="150" decoding="async" data-nimg="1" className="rounded-lg md:rounded md:w-[195px] md:h-full w-[120px] h-[75px] group-hover:md:scale-105 transition-all object-cover duration-500 ease-in-out group-hover:opacity-100 scale-100 blur-0 grayscale-0" src={blog.imageUrl} />
                                        </a>
                                        <aside className="mt-0 descriptions title__movie text-left w-[70%] md:w-[65%] leading-7">
                                            <a className="text-sm md:text-base xl:text-xl font-normal md:font-bold hover:text-blue-10 transition-all duration-300 overflow-hidden leading-5" href={blog.href}>{blog.title}</a>
                                            <div className="card__votes flex mt-2">
                                                <button type="button" className="h-[20px] text-xs text-white hover:text-white mr-2 bg-blue-400 hover:bg-blue-800 focus:ring-1 focus:ring-blue-300 rounded px-3">
                                                    <ThumbUp style={{ fontSize: 14 }}/>
                                                    <span className="ml-2">Thích</span>
                                                </button>
                                                <button className="text-xs text-black-10 bg-grey-30 h-[20px] rounded mr-2 px-3 hover:text-black-10">
                                                    <Visibility style={{ fontSize: 14 }}/>
                                                    <span className="ml-2">{blog.likes}</span>
                                                </button>
                                            </div>
                                        </aside>
                                    </aside>
                                ))}

                            </article>
                        </article>
                        <div className="text-center mt-12  transition-all duration-300 ease-in-out">
                            <a type="button" className="text-[#f26b38] hover:text-white w-40 border border-[#fb9440] hover:bg-[#fb9440] transition-all duration-300 focus:ring-1 focus:outline-none focus:ring-[#fb9440] rounded text-sm px-5 py-2.5 text-center inline-flex items-center dark:hover:bg-[#fb9440] dark:focus:ring-[#fb9440] mr-2 mb-2 justify-center" href="/binh-luan-phim/">Xem thêm
                                <ExpandMore />
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default BlogComponent;

