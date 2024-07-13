import TitleItem from "../components/common_components/comom_item/TitleItem";
import { Breadcrumbs, Link, Typography } from "@mui/material";
import MovieSuggestionComponent from '../components/common_components/MovieSuggestionComponent';
import BookingComponent from '../components/postList_components/BookingComponent';
import { NavigateNext } from "@mui/icons-material";

const DetailPostPage = () => {
    return (
        <div className="grid grid-cols-1 screen1200:grid-cols-6 my-0 mx-auto screen1390:max-w-screen-xl xl:max-w-screen-screen1200 lg:max-w-4xl md:max-w-4xl gap-8 py-7 px-4 lg:px-0">
            <div className="lg:col-span-4">
                <Breadcrumbs separator={<NavigateNext fontSize="small" />} aria-label="breadcrumb">
                    <Link underline="hover" key="1" color="inherit" href="/">
                        MUI
                    </Link>
                    <Link underline="hover" key="2" color="inherit" href="/material-ui/getting-started/installation/">
                        Core
                    </Link>
                    <Typography key="3" color="text.primary">
                        Breadcrumb
                    </Typography>
                </Breadcrumbs>
            </div>
            <div className="hidden screen1200:block lg:col-span-2">
                <div className="card w-full h-auto mb-8">
                    <TitleItem title="MUA VÉ NHANH" />
                    <BookingComponent />
                </div>
                <MovieSuggestionComponent />
            </div>
        </div>
    );
};

export default DetailPostPage;
