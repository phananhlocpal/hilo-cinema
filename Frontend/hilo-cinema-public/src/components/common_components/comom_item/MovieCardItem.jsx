import { Payments } from '@mui/icons-material';

// eslint-disable-next-line react/prop-types
const MovieCardItem = ({widthCard = '140px', heightCard = '210px', title="N/A", imageUrl="" }) => {
    return (
        <div className="list-none text-sm text-black py-2 transition-all duration-300">
            <div className={"inline-block relative max-w-full w-["+widthCard+ "] h-[" + heightCard+ "]"}>
                <div className="inline-block cursor-pointer rounded overflow-hidden card__movies max-w-full false ">
                    <div className="object-cover rounded relative card__img max-w-full">
                        <div className="absolute hidden md:block w-full h-full z-10 cursor-pointer bg-[#00000080] transition-all duration-300 ease-in-out opacity-0 hover:opacity-100">
                            <div className="card__hover__content flex flex-col justify-center items-center w-full h-full">
                                <a type="button" className="text-white bg-[#f26b38] w-[120px] h-[40px] hover:bg-[#fb9440] rounded text-sm px-5 py-2.5 text-center inline-flex items-center dark:hover:bg-[#fb9440] dark:focus:ring-[#fb9440]">
                                    <Payments alt="Logo Buy Ticket" loading="lazy" width="20" height="20" decoding="async" data-nimg="1" className="mr-2"/>
                                    Mua vé
                                </a>
                            </div>
                        </div>
                        <a href="/dat-ve/inside-out-2/">
                            <img alt="inside-out-2" loading="lazy" width={widthCard} height={heightCard} decoding="async" data-nimg="1" className="undefined object-cover duration-500 ease-in-out group-hover:opacity-100 scale-100 blur-0 grayscale-0)" src={imageUrl} />
                        </a>
                        <div className="votes">
                            <p className="absolute right-[5px] bottom-10">
                                <span>
                                    <svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="star" className="svg-inline--fa fa-star text-yellow-300 mr-5 text-[12px]" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 576 512">
                                        <path fill="currentColor" d="M316.9 18C311.6 7 300.4 0 288.1 0s-23.4 7-28.8 18L195 150.3 51.4 171.5c-12 1.8-22 10.2-25.7 21.7s-.7 24.2 7.9 32.7L137.8 329 113.2 474.7c-2 12 3 24.2 12.9 31.3s23 8 33.8 2.3l128.3-68.5 128.3 68.5c10.8 5.7 23.9 4.9 33.8-2.3s14.9-19.3 12.9-31.3L438.5 329 542.7 225.9c8.6-8.5 11.7-21.2 7.9-32.7s-13.7-19.9-25.7-21.7L381.2 150.3 316.9 18z"></path>
                                    </svg>
                                </span>
                                <span className="text-[18px] font-bold text-white">9</span>
                            </p>
                        </div>
                    </div>
                </div>
                <div className="Card_card__title__kFoFc mt-2" >
                    <a type="button" className="text-sm font-semibold not-italic w-[140px] overflow-hidden" href="/dat-ve/inside-out-2/">{title}</a>
                </div>
            </div>
        </div>
    );
};

export default MovieCardItem;