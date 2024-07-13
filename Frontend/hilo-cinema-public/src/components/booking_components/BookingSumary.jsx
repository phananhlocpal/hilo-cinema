import { useSelector } from 'react-redux';
import PropTypes from "prop-types";

const BookingSummary = (props) => {
    const movieBooking = useSelector((state) => state.booking.movieBooking);
    const totalAmount = useSelector((state) => state.booking.totalAmount);

    console.log(totalAmount);
    return (
        <div className="booking__summary md:mb-4">
            <div className="h-[6px] bg-primary rounded-t-lg"></div>
            <div className="bg-white p-4 grid grid-cols-3 xl:gap-2 items-center">
                <div className="row-span-2 md:row-span-1 xl:row-span-2 block md:hidden xl:block">
                    <img alt="Chờ Người Nơi Pháo Hoa Rực Rỡ" loading="lazy" width="100" height="150" decoding="async" data-nimg="1" className="xl:w-full xl:h-full md:w-[80px] md:h-[120px] w-[90px] h-[110px] rounded object-cover duration-500 ease-in-out group-hover:opacity-100 scale-100 blur-0 grayscale-0)" src="https://cdn.galaxycine.vn/media/2024/6/14/abl-500_1718351220871.jpg" style={{ backgroundColor: "transparent" }} />
                </div>
                <div className="row-span-2 md:row-span-1 xl:row-span-2 hidden md:block xl:hidden">
                    <img alt="Chờ Người Nơi Pháo Rực Rỡ" loading="lazy" width="100" height="150" decoding="async" data-nimg="1" className=" w-[220px] h-[150px] rounded object-cover duration-500 ease-in-out group-hover:opacity-100 scale-100 blur-0 grayscale-0)" src="https://cdn.galaxycine.vn/media/2024/6/14/abl-750_1718351221256.jpg" style={{ color: "transparent" }} />
                </div>
                <div className="flex-1 col-span-2 md:col-span-1 row-span-1 xl:col-span-2">
                    <h3 className="text-sm xl:text-base font-bold xl:mb-2 ">
                        {movieBooking.title}
                    </h3>
                    <p className="text-sm inline-block">{movieBooking.type}</p>
                    <span> - </span>
                    <div className="xl:mt-2 ml-2 xl:ml-0 inline-block">
                        <span className="inline-flex items-center justify-center w-[38px] h-7 bg-primary rounded text-sm text-center text-white font-bold not-italic">
                            T16
                        </span>
                    </div>
                </div>
                <div className="col-span-2 md:col-span-1 xl:col-span-3">
                    <div>
                        <div className="xl:mt-4 text-sm xl:text-base">
                            <strong>{movieBooking.theater}</strong>
                            <span> - </span>
                            <span className="text-sm xl:text-base">{movieBooking.room}</span>
                        </div>
                        <div className="xl:mt-2 text-sm xl:text-base">
                            <span>Suất: </span>
                            <strong>{movieBooking.time}</strong>
                            <span> - </span>
                            <span className="capitalize text-sm">
                                {movieBooking.date}, <strong>30/06/2024</strong>
                            </span>
                        </div>
                    </div>
                    <div className="xl:block hidden">
                        <div className="my-4 border-t border-black border-dashed xl:block hidden"></div>
                        <div className="flex justify-between text-sm mt-2">
                            <div>
                                <strong>2x </strong>
                                <span>Ghế đơn</span>
                                <div>
                                    <span>Ghế: </span>
                                    <strong>I16, I17</strong>
                                </div>
                            </div>
                            <span className="inline-block font-bold ">190.000&nbsp;₫</span>
                        </div>
                        <div className="flex justify-between text-sm mt-2">
                            <div>
                                <strong>1x </strong>
                                <span>Ghế đôi</span>
                                <div>
                                    <span>Ghế: </span>
                                    <strong>I16, I17</strong>
                                </div>
                            </div>
                            <span className="inline-block font-bold ">190.000&nbsp;₫</span>
                        </div>
                    </div>
                    <div className="xl:block hidden">
                        <div className="my-4 border-t border-black border-dashed xl:block hidden"></div>
                        <div className="flex justify-between text-sm">
                            <span>
                                <strong>1x </strong>
                                <span>iCombo 2 Big Extra STD</span>
                            </span>
                            <span className="inline-block font-bold ">129.000&nbsp;₫</span>
                        </div>
                        <div className="flex justify-between text-sm">
                            <span>
                                <strong>1x </strong>
                                <span>iCombo 2 Big STD</span>
                            </span>
                            <span className="inline-block font-bold ">109.000&nbsp;₫</span>
                        </div>
                        <div className="flex justify-between text-sm">
                            <span>
                                <strong>1x </strong>
                                <span>iCombo Optimus Prime Promotion 199K</span>
                            </span>
                            <span className="inline-block font-bold ">199.000&nbsp;₫</span>
                        </div>
                    </div>
                    <div className="my-4 border-t border-black border-dashed xl:block hidden"></div>
                </div>
                <div className="xl:flex hidden justify-between col-span-3">
                    <strong className="text-base">Tổng cộng</strong>
                    <span className="inline-block font-bold text-primary">
                        {totalAmount.toLocaleString()}&nbsp;₫
                    </span>
                </div>
            </div>
            <div className="mt-8 xl:flex hidden">
                <button onClick={props.comeBack} className="w-1/2 mr-2 py-2 text-primary">
                    <span>Quay lại</span>
                </button>
                <button onClick={props.onContinue} className="w-1/2 ml-2 py-2 bg-primary text-white border rounded-md hover:bg-orange-20">
                    <span>Tiếp tục</span>
                </button>
            </div>
        </div>
    );
};

BookingSummary.propTypes = {
    onContinue: PropTypes.func,
    comeBack:PropTypes.func,
}


export default BookingSummary;
