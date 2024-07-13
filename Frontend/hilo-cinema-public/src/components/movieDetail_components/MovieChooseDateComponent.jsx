import { useEffect, useRef } from 'react';
import PropTypes from 'prop-types';
import Slider from 'react-slick';
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";

const MovieChooseDateComponent = ({ schedule, selectedDate, onDateChange }) => {
    const sliderRef = useRef(null);

    useEffect(() => {
        const handleWheel = (event) => {
            if (sliderRef.current) {
                if (event.deltaX < 0) {
                    sliderRef.current.slickPrev();
                } else {
                    sliderRef.current.slickNext();
                }
            }
        };

        const sliderElement = document.querySelector('.slick-track');
        sliderElement.addEventListener('wheel', handleWheel);

        return () => {
            sliderElement.removeEventListener('wheel', handleWheel);
        };
    }, []);

    // const activeSchedule() => {

    // }

    return (
        <div>
            <div className="movie__filter grid grid-cols-1 sm:grid-cols-6 lg:grid-cols-5 xl:grid-cols-12 items-center">
                <div className="filter__date order-2 sm:order-1 sm:col-span-3 md:col-span-3 xl:col-span-7 lg:col-span-3 px-7 mt-6 md:mt-0">
                    <div className="slick-slider slick-initialized flex" dir="ltr">
                        <button className="css-sjy0nk" style={{ display: 'block' }}>
                            <svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="angle-left" className="svg-inline--fa fa-angle-left text-[#333333]" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 320 512">
                                <path fill="currentColor" d="M41.4 233.4c-12.5 12.5-12.5 32.8 0 45.3l160 160c12.5 12.5 32.8 12.5 45.3 0s12.5-32.8 0-45.3L109.3 256 246.6 118.6c12.5-12.5 12.5-32.8 0-45.3s-32.8-12.5-45.3 0l-160 160z"></path>
                            </svg>
                        </button>
                        <div className="slick-list mx-2">
                            <div className="slick-track" style={{ width: '535px', opacity: 1, transform: 'translate3d(0px, 0px, 0px)' }}>
                                <Slider ref={sliderRef} {...settings}>
                                    {console.log(schedule)}
                                    {schedule.map((detailSchedule, index) => {
                                        {/* console.log(detailSchedule); */}
                                        const { dayOfWeek, formattedDate } = formatDate(detailSchedule.day);
                                        return (
                                            <div key={index} data-index={index} className="slick-slide slick-active" tabIndex="-1" aria-hidden="false" style={{ outline: 'none' }}>
                                                <div>
                                                    <div className="mx-2" tabIndex="-1" style={{ width: '100%', display: 'inline-block' }}>
                                                        <a
                                                            className={`flex flex-wrap items-center capitalize text-center text-sm w-[80px] h-[65px] rounded-[5px] py-2 cursor-pointer ${selectedDate === detailSchedule.day ? 'bg-[#034ea2] text-white' : ''}`}
                                                            onClick={() => onDateChange(detailSchedule.day)}
                                                        >
                                                            <span className="inline-block w-full">{dayOfWeek}</span>
                                                            <span className="inline-block w-full">{formattedDate}</span>
                                                        </a>
                                                    </div>
                                                </div>
                                            </div>
                                        );
                                    })}
                                </Slider>
                            </div>
                        </div>
                        <button className="css-10rwe4n" style={{ display: 'block' }}>
                            <svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="angle-right" className="svg-inline--fa fa-angle-right text-[#333333]" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 320 512">
                                <path fill="currentColor" d="M278.6 233.4c12.5 12.5 12.5 32.8 0 45.3l-160 160c-12.5 12.5-32.8 12.5-45.3 0s-12.5-32.8 0-45.3L210.7 256 73.4 118.6c-12.5-12.5-12.5-32.8 0-45.3s32.8-12.5 45.3 0l160 160z"></path>
                            </svg>
                        </button>
                    </div>
                </div>
                {/* <div className="filter__location order-1 sm:order-2 sm:col-span-3 md:col-span-3 xl:col-span-5 lg:col-span-2 grid grid-cols-2 ml-2 gap-1">
                    <div className="col-span-1">
                        <div>
                            <div aria-label="Dropdown select" aria-expanded="false" tabIndex="0" direction="ltr" className="react-dropdown-select text-sm css-y6f7bg e1gzf2xs0" color="#0074D9">
                                <div className="react-dropdown-select-content react-dropdown-select-type-single css-1m5113o e1gn6jc30">
                                    <span>Toàn quốc</span>
                                    <input tabIndex="-1" className="react-dropdown-select-input css-1q95dnp e11wid6y0" readOnly placeholder="" value="" />
                                </div>
                                <div tabIndex="-1" className="react-dropdown-select-dropdown-handle css-ago8sv e1vudypg0" rotate="1" color="#0074D9">
                                    <svg fill="currentColor" viewBox="0 0 40 40">
                                        <path d="M31 26.4q0 .3-.2.5l-1.1 1.2q-.3.2-.6.2t-.5-.2l-8.7-8.8-8.8 8.8q-.2.2-.5.2t-.5-.2l-1.2-1.2q-.2-.2-.2-.5t.2-.5l10.4-10.4q.3-.2.6-.2t.5.2l10.4 10.4q.2.2.2.5z"></path>
                                    </svg>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className="col-span-1">
                        <div>
                            <div aria-label="Dropdown select" aria-expanded="false" tabIndex="0" direction="ltr" className="react-dropdown-select text-sm css-y6f7bg e1gzf2xs0" color="#0074D9">
                                <div className="react-dropdown-select-content react-dropdown-select-type-single css-1m5113o e1gn6jc30">
                                    <span>Tất cả rạp</span>
                                    <input tabIndex="-1" className="react-dropdown-select-input css-1q95dnp e11wid6y0" readOnly placeholder="" value="" />
                                </div>
                                <div tabIndex="-1" className="react-dropdown-select-dropdown-handle css-ago8sv e1vudypg0" rotate="1" color="#0074D9">
                                    <svg fill="currentColor" viewBox="0 0 40 40">
                                        <path d="M31 26.4q0 .3-.2.5l-1.1 1.2q-.3.2-.6.2t-.5-.2l-8.7-8.8-8.8 8.8q-.2.2-.5.2t-.5-.2l-1.2-1.2q-.2-.2-.2-.5t.2-.5l10.4-10.4q.3-.2.6-.2t.5.2l10.4 10.4q.2.2.2.5z"></path>
                                    </svg>
                                </div>
                            </div>
                        </div>
                    </div>
                </div> */}
            </div>
        </div>
    );
};

MovieChooseDateComponent.propTypes = {
    schedule: PropTypes.arrayOf(
        PropTypes.shape({
            day: PropTypes.string.isRequired,
            date: PropTypes.string.isRequired,
            isActive: PropTypes.bool
        })
    ).isRequired,
    selectedDate: PropTypes.string.isRequired,
    onDateChange: PropTypes.func.isRequired,
};

const daysOfWeek = ['Chủ Nhật', 'Thứ Hai', 'Thứ Ba', 'Thứ Tư', 'Thứ Năm', 'Thứ Sáu', 'Thứ Bảy'];

const formatDate = (dateString) => {
    const date = new Date(dateString);
    const today = new Date();
    const isToday = date.toDateString() === today.toDateString();

    const dayOfWeek = isToday ? 'Hôm nay' : daysOfWeek[date.getDay()];
    const formattedDate = `${date.getDate()}/${date.getMonth() + 1}`;

    return { dayOfWeek, formattedDate };
};

const settings = {
    dots: true,
    infinite: true,
    speed: 500,
    slidesToShow: 3,
    slidesToScroll: 1,
    draggable: true,
    swipeToSlide: true,
    arrows: true,
    wheel: true,
    wheelScrollSensitivity: 1,
    responsive: [
        {
            breakpoint: 1024,
            settings: {
                slidesToShow: 3,
                slidesToScroll: 1,
                infinite: true,
                dots: true
            }
        },
        {
            breakpoint: 600,
            settings: {
                slidesToShow: 2,
                slidesToScroll: 1,
                initialSlide: 2
            }
        },
        {
            breakpoint: 480,
            settings: {
                slidesToShow: 1,
                slidesToScroll: 1
            }
        }
    ]
};

export default MovieChooseDateComponent;
